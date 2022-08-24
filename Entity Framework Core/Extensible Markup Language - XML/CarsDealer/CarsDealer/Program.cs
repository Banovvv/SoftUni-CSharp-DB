using CarsDealer.Data;
using CarsDealer.Initializer;
using CarsDealer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarsDealer
{
    internal class Program
    {
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";

        static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                DbInitializer.Initialize(context);
                DbInitializer.Seed(context);

                // 6. Cars With Distance
                File.WriteAllText($"{ResultsDirectoryPath}/cars.xml", GetCarsWithDistance(context));

                // 7. Cars from make BMW
                File.WriteAllText($"{ResultsDirectoryPath}/bmw-cars.xml", GetCarsFromMakeBmw(context));

                // 8. Local Suppliers
                File.WriteAllText($"{ResultsDirectoryPath}/local-suppliers.xml", GetLocalSuppliers(context));

                // 9. Cars with Their List of Parts
                File.WriteAllText($"{ResultsDirectoryPath}/cars-and-parts.xml", GetCarsWithTheirListOfParts(context));

                // 10. Total Sales by Customer
                File.WriteAllText($"{ResultsDirectoryPath}/customers-total-sales.xml", GetTotalSalesByCustomer(context));

                // 11. Total Sales by Customer
                File.WriteAllText($"{ResultsDirectoryPath}/sales-discounts.xml", GetSalesWithAppliedDiscount(context));
            }
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IEnumerable<ExportCarWithDistanceDTO> cars = context.Cars.Where(x => x.TravelledDistance >= 200000)
                .OrderBy(x => x.Make)
                .OrderBy(x => x.Model)
                .Take(10)
                .Select(x => new ExportCarWithDistanceDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCarWithDistanceDTO>), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IEnumerable<ExportCarBMWDTO> cars = context.Cars.Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarBMWDTO
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCarBMWDTO>), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IEnumerable<ExportLocalSupplierDTO> suppliers = context.Suppliers.Where(x => !x.IsImporter)
                .Select(x => new ExportLocalSupplierDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportLocalSupplierDTO>), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IEnumerable<ExportCarWithPartsDTO> cars = context.Cars
                .Select(x => new ExportCarWithPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.CarParts.Where(p => p.CarId == x.Id)
                        .Select(p => new ExportPartDTO
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Make)
                .Take(5)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCarWithPartsDTO>), new XmlRootAttribute("cars"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IEnumerable<ExportCustomerSalestDTO> customers = context.Customers.Where(x => x.BoughtCars.Any())
                .Select(x => new ExportCustomerSalestDTO
                {
                    FullName = x.Name,
                    BoughtCars = x.BoughtCars.Count(),
                    SpentMoney = context.PartCars
                        .Where(pc => x.BoughtCars
                            .Where(bc => bc.CustomerId == x.Id)
                            .Select(bc => bc.CarId)
                            .Contains(pc.CarId))
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCustomerSalestDTO>), new XmlRootAttribute("customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            IEnumerable<ExportSalesWithDiscountDTO> sales = context.Sales
                    .Select(x => new ExportSalesWithDiscountDTO()
                    {
                        Car = new ExportCarWithDistanceDTO()
                        {
                            Make = x.Car.Make,
                            Model = x.Car.Model,
                            TravelledDistance = x.Car.TravelledDistance
                        },
                        Discount = x.Discount,
                        CustomerName = x.Customer.Name,
                        Price = x.Car.CarParts.Sum(cp => cp.Part.Price),
                        PriceWithDiscount = x.Car.CarParts.Sum(cp => cp.Part.Price) -
                                            x.Car.CarParts.Sum(cp => cp.Part.Price) * x.Discount / 100
                    })
                    .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportSalesWithDiscountDTO>), new XmlRootAttribute("sales"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}
