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
                //Console.WriteLine(ImportUsers(context, $"{DatasetsDirectoryPath}/users.xml"));

                // 2. Import Products
                //Console.WriteLine(ImportProducts(context, $"{DatasetsDirectoryPath}/products.xml"));

                // 3. Import Categories
                Console.WriteLine(ImportCategories(context, $"{DatasetsDirectoryPath}/categories.xml"));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));
            IEnumerable<User> users = (User[])serializer.Deserialize(File.OpenRead(inputXml));

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Product[]), new XmlRootAttribute("Products"));
            IEnumerable<Product> products = (Product[])serializer.Deserialize(File.OpenRead(inputXml));

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Category[]), new XmlRootAttribute("Categories"));
            IEnumerable<Category> categories = (Category[])serializer.Deserialize(File.OpenRead(inputXml));

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }
    }
}
