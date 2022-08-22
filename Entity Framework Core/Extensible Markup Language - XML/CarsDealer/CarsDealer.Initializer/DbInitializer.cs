using CarsDealer.Data;
using CarsDealer.Models;
using CarsDealer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarsDealer.Initializer
{
    public class DbInitializer
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";

        public static void Initialize(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("CarDealer database created successfully.");
        }

        public static void Seed(CarDealerContext context)
        {

            // 1. Import Suppliers
            var suppliers = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, suppliers));

            // 2.Import Parts
            var parts = File.ReadAllText($"{DatasetsDirectoryPath}/parts.xml");
            Console.WriteLine(ImportParts(context, parts));

            // 3. Import Cars
            var cars = File.ReadAllText($"{DatasetsDirectoryPath}/cars.xml");
            Console.WriteLine(ImportCars(context, cars));

            // 4. Import Customers
            var customers = File.ReadAllText($"{DatasetsDirectoryPath}/customers.xml");
            Console.WriteLine(ImportCustomers(context, customers));

            // 5. Import Sales
            var sales = File.ReadAllText($"{DatasetsDirectoryPath}/sales.xml");
            Console.WriteLine(ImportSales(context, sales));
        }

        private static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Supplier[]), new XmlRootAttribute("Suppliers"));

            using (var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Supplier> suppliers = (Supplier[])serializer.Deserialize(stringReader);

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                return $"Successfully imported {suppliers.Count()}";
            }
        }
        private static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Part[]), new XmlRootAttribute("Parts"));

            using (var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Part> parts = (Part[])serializer.Deserialize(stringReader);

                foreach (var part in parts)
                {
                    if (context.Suppliers.Any(x => x.Id == part.SupplierId))
                    {
                        context.Parts.Add(part);
                    }
                }
                context.SaveChanges();

                return $"Successfully imported {parts.Count()}";
            }
        }
        private static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarDTO[]), new XmlRootAttribute("Cars"));

            using (var stringReader = new StringReader(inputXml))
            {
                var carDtos = (ImportCarDTO[])serializer.Deserialize(stringReader);

                var cars = new List<Car>();
                var partCars = new List<PartCar>();

                foreach (var carDto in carDtos)
                {
                    var car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TravelledDistance = carDto.TravelledDistance,
                    };

                    var parts = carDto.Parts
                        .Where(pdto => context.Parts.Any(p => p.Id == pdto.Id))
                        .Select(p => p.Id)
                        .Distinct();

                    foreach (var part in parts)
                    {
                        var partCar = new PartCar()
                        {
                            PartId = part,
                            Car = car
                        };

                        partCars.Add(partCar);
                    }

                    cars.Add(car);
                }

                context.AddRange(cars);
                context.AddRange(partCars);
                context.SaveChanges();

                return $"Successfully imported {cars.Count}";
            }
        }
        private static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Customer[]), new XmlRootAttribute("Customers"));

            using (var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Customer> customers = (Customer[])serializer.Deserialize(stringReader);

                context.Customers.AddRange(customers);
                context.SaveChanges();

                return $"Successfully imported {customers.Count()}";
            }
        }
        private static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Sale[]), new XmlRootAttribute("Sales"));

            using (var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Sale> sales = (Sale[])serializer.Deserialize(stringReader);

                foreach (var sale in sales)
                {
                    if (context.Cars.Any(x => x.Id == sale.CarId))
                    {
                        context.Sales.Add(sale);
                    }
                }
                context.SaveChanges();

                return $"Successfully imported {sales.Count()}";
            }
        }
    }
}
