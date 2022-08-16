using AutoMapper;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Initializer;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ProductsShop
{
    public class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Results";

        static void Main(string[] args)
        {
            using (var context = new ProductsShopContext())
            {
                //DbInitializer.Initialize(context);

                // 1. Import Users
                //var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
                //Console.WriteLine(ImportUsers(context, inputJson));

                // 2. Import Products
                var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
                Console.WriteLine(ImportProducts(context, inputJson));
            }
        }

        public static string ImportUsers(ProductsShopContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var users = JsonConvert.DeserializeObject<List<User>>(inputJson, serializerSettings);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductsShopContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson, serializerSettings);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
    }
}
