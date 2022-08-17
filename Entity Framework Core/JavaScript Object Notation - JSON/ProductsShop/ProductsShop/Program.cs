using AutoMapper;
using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Initializer;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductsShop
{
    public class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        static void Main(string[] args)
        {
            using (var context = new ProductsShopContext())
            {
                //DbInitializer.Initialize(context);

                // 1.Import Users
                //var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
                //Console.WriteLine(ImportUsers(context, inputJson));

                // 2. Import Products
                //var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
                //Console.WriteLine(ImportProducts(context, inputJson));

                // 3. Import Categories
                //var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
                //Console.WriteLine(ImportCategories(context, inputJson));

                // 4. Import Categories and Products
                //var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/categories-products.json");
                //Console.WriteLine(ImportCategoryProducts(context, inputJson));

                // 5. Export Products in Range
                File.WriteAllText($"{ResultsDirectoryPath}/categories-products.json", GetProductsInRange(context));
            }
        }

        #region Import Functions
        public static string ImportUsers(ProductsShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson, serializerSettings);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
        public static string ImportProducts(ProductsShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson, serializerSettings);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
        public static string ImportCategories(ProductsShopContext context, string inputJson)
        {          
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, serializerSettings);
            
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        public static string ImportCategoryProducts(ProductsShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        #endregion

        public static string GetProductsInRange(ProductsShopContext context)
        {
            var products = context.Products.Where(x=>x.Price >= 500 && x.Price <= 1000)
                    .OrderBy(x=>x.Price)
                    .Select(x=> new
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Seller = x.Seller.FirstName + " " + x.Seller.LastName
                    })
                    .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}
