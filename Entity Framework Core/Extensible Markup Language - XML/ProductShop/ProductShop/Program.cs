using ProductShop.Data;
using ProductShop.Initializer;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProductShop
{
    public class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";
        static void Main(string[] args)
        {
            using(var context = new ProductShopContext())
            {
                //DbInitializer.Initialize(context);

                XDocument users = XDocument.Load($"{DatasetsDirectoryPath}/users.xml");
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var users = new List<string>();
            return $"Successfully imported {users.Count}";
        }
    }
}
