using CarsDealer.Data;
using CarsDealer.Initializer;
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
                var suppliers = File.ReadAllText($"{DatasetsDirectoryPath}/suppliers.xml");
                Console.WriteLine(ImportSuppliers(context, suppliers));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serialzier = new XmlSerializer(typeof(Supplier[]), new XmlRootAttribute("Suppliers"));

            using(var stringReader = new StringReader(inputXml))
            {
                IEnumerable<Supplier> suppliers = (Supplier[])serialzier.Deserialize(stringReader);

                context.Suppliers.AddRange(suppliers);
                context.SaveChanges();

                return $"Successfully imported {suppliers.Count()}";
            }
        }
    }
}
