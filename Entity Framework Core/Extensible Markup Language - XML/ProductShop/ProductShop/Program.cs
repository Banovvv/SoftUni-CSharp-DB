using ProductShop.Data;
using ProductShop.Initializer;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

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

                // 1. Import Users
                XDocument users = XDocument.Load($"{DatasetsDirectoryPath}/users.xml");
                Console.WriteLine(ImportUsers(context, users.ToString()));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));
            IEnumerable<User> users = (User[])serializer.Deserialize(File.OpenRead($"{DatasetsDirectoryPath}/users.xml"));

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}
