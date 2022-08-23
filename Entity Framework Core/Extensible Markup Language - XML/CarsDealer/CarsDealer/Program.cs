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
                File.WriteAllText($"{ResultsDirectoryPath}/cars.xml", GetCarsWithDistance(context));
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
    }
}
