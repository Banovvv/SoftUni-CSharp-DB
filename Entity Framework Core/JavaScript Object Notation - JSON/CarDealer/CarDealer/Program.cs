using CarDealer.Data;
using CarDealer.Initializer;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CarDealer
{
    internal class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                DbInitializer.Initialize(context);

                // 01.Import Suppliers
                var suppliersJson = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.json");
                Console.WriteLine(ImportSuppliers(context, suppliersJson));

                //// 02. Import Parts
                var partsJson = File.ReadAllText($"{DatasetsDirectoryPath}/parts.json");
                Console.WriteLine(ImportParts(context, partsJson));

                // 03. Import Cars
                var carsJson = File.ReadAllText($"{DatasetsDirectoryPath}/cars.json");
                Console.WriteLine(ImportCars(context, carsJson));

                // 04. Import Customers
                var customersJson = File.ReadAllText($"{DatasetsDirectoryPath}/customers.json");
                Console.WriteLine(ImportCustomers(context, customersJson));

                // 05. Import Sales
                var salesJson = File.ReadAllText($"{DatasetsDirectoryPath}/sales.json");
                Console.WriteLine(ImportSales(context, salesJson));

                // 06. Export Ordered Customers
                File.WriteAllText($"{ResultsDirectoryPath}/ordered-customers.json", GetOrderedCustomers(context));

                // 07. Export Cars from Make Toyota
                File.WriteAllText($"{ResultsDirectoryPath}/toyota-cars.json", GetCarsFromMakeToyota(context));

                // 08. Export Local Suppliers
                File.WriteAllText($"{ResultsDirectoryPath}/local-suppliers.json", GetLocalSuppliers(context));

                // 09. Export Cars with Their List of Parts
                File.WriteAllText($"{ResultsDirectoryPath}/cars-and-parts.json", GetCarsWithTheirListOfParts(context));

                // 10. Export Total Sales by Customer
                File.WriteAllText($"{ResultsDirectoryPath}/customers-total-sales.json", GetTotalSalesByCustomer(context));
            }
        }

        #region Import Methods
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson, serializerSettings);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson, serializerSettings)
                    .Where(x => context.Suppliers.Select(s => s.Id).Contains(x.SupplierId))
                    .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson, serializerSettings);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson, serializerSettings);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";

        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson, serializerSettings);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        #endregion

        #region Export Methods
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(x => !x.IsImporter)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    Car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    Parts = x.Parts
                        .Select(p => new
                        {
                            Name = p.Name,
                            Price = $"p.Part.Price:F2"
                        })
                        .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                    .Where(c => c.BoughtCars.Count >= 1)
                    .Select(s => new
                    {
                        FullName = s.Name,
                        BoughtCars = s.BoughtCars.Count,
                        SpentMoney = s.BoughtCars.Sum(c => c.Car.Parts.Sum(p => p.Price))
                    })
                    .OrderByDescending(o => o.SpentMoney)
                    .ThenByDescending(o => o.BoughtCars)
                    .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    Price = s.Car.Parts.Sum(pc => pc.Price).ToString("f2"),
                    PriceWithDiscount = (s.Car.Parts.Sum(pc => pc.Price) -
                                        s.Car.Parts.Sum(pc => pc.Price) * s.Discount / 100).ToString("f2")

                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
        #endregion
    }
}
