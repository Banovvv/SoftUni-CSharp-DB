using CarsDealer.Data;
using CarsDealer.Initializer;
using CarsDealer.Models;
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
                //DbInitializer.Initialize(context);
                //DbInitializer.Seed(context);

                // 6. Cars With Distance
                //File.WriteAllText($"{ResultsDirectoryPath}/cars.xml", GetCarsWithDistance(context));

                // 7. Cars from make BMW
                //File.WriteAllText($"{ResultsDirectoryPath}/bmw-cars.xml", GetCarsFromMakeBmw(context));

                // 8. Local Suppliers
                //File.WriteAllText($"{ResultsDirectoryPath}/local-suppliers.xml", GetLocalSuppliers(context));

                // 9. Cars with Their List of Parts
                File.WriteAllText($"{ResultsDirectoryPath}/cars-and-parts.xml", GetCarsWithTheirListOfParts(context));
            }
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IEnumerable<ExportCarWithDistanceDTO> cars = context.Cars.Where(x => x.TravelledDistance >= 200000)
                .OrderBy(x => x.Make)
                .OrderBy(x => x.Model)
                .Take(10)
                .Select(x=> new ExportCarWithDistanceDTO
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
    }
}
