using CarsDealer.Data;
using CarsDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarsDealer
{
    internal class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";

        static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                //DbInitializer.Initialize(context);

                // 1. Import Suppliers
                //var suppliers = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.xml");
                //Console.WriteLine(ImportSuppliers(context, suppliers));

                // 2. Import Parts
                var parts = File.ReadAllText($"{DatasetsDirectoryPath}/parts.xml");
                Console.WriteLine(ImportParts(context, parts));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serialzier = new XmlSerializer(typeof(Supplier[]), new XmlRootAttribute("Suppliers"));

            using (var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Supplier> suppliers = (Supplier[])serialzier.Deserialize(stringReader);

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                return $"Successfully imported {suppliers.Count()}";
            }
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
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
    }
}
