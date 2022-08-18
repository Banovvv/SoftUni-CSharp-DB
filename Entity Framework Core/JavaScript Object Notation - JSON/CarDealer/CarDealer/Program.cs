using CarDealer.Data;
using CarDealer.Initializer;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            using(var context = new CarDealerContext())
            {
                //DbInitializer.Initialize(context);

                // 01. Import Suppliers
                //var suppliersJson = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.json");
                //Console.WriteLine(ImportSuppliers(context, suppliersJson));

                // 02. Import Parts
                //var partsJson = File.ReadAllText($"{DatasetsDirectoryPath}/parts.json");
                //Console.WriteLine(ImportParts(context, partsJson));

                // 03. Import Cars
                //var carsJson = File.ReadAllText($"{DatasetsDirectoryPath}/cars.json");
                //Console.WriteLine(ImportCars(context, carsJson));

                // 04. Import Customers
                //var customersJson = File.ReadAllText($"{DatasetsDirectoryPath}/customers.json");
                //Console.WriteLine(ImportCustomers(context, customersJson));

                // 05. Import Sales
                var salesJson = File.ReadAllText($"{DatasetsDirectoryPath}/sales.json");
                Console.WriteLine(ImportSales(context, salesJson));
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
                    .Where(x=> context.Suppliers.Select(s=>s.Id).Contains(x.SupplierId))
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
    }
}
