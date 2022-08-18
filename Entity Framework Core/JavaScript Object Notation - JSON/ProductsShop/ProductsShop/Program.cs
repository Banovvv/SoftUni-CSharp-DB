using Newtonsoft.Json;
using ProductsShop.Data;
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
                //var inputJson1 = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
                //Console.WriteLine(ImportUsers(context, inputJson1));

                // 2. Import Products
                //var inputJson2 = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
                //Console.WriteLine(ImportProducts(context, inputJson2));

                // 3. Import Categories
                //var inputJson3 = File.ReadAllText($"{DatasetsDirectoryPath}/products.json");
                //Console.WriteLine(ImportCategories(context, inputJson3));

                // 4. Import Categories and Products
                //var inputJson4 = File.ReadAllText($"{DatasetsDirectoryPath}/categories-products.json");
                //Console.WriteLine(ImportCategoryProducts(context, inputJson4));

                // 5. Export Products in Range
                //File.WriteAllText($"{ResultsDirectoryPath}/categories-products.json", GetProductsInRange(context));

                // 6. Export Successfully Sold Products
                //File.WriteAllText($"{ResultsDirectoryPath}/categories-by-products.json", GetSoldProducts(context));

                // 7. Export Users and Products
                File.WriteAllText($"{ResultsDirectoryPath}/users-and-products.json", GetUsersWithProducts(context));
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
            var products = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                    .OrderBy(x => x.Price)
                    .Select(x => new
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Seller = x.Seller.FirstName + " " + x.Seller.LastName
                    })
                    .ToList();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
        public static string GetSoldProducts(ProductsShopContext context)
        {
            var categories = context.Categories
                    .OrderByDescending(x => x.Products.Count())
                    .Select(x => new
                    {
                        Category = x.Name,
                        ProductsCount = x.Products.Count(),
                        AveragePrice = $"{x.Products.Average(p => p.Price):F2}",
                        TotalRevenue = $"{x.Products.Sum(p => p.Price):F2}"
                    })
                    .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }
        public static string GetUsersWithProducts(ProductsShopContext context)
        {
            var users = context.Users.Where(x => x.ProductsSold.Count > 0)
                .Select(x=> new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                        {
                            Count = x.ProductsSold.Count,
                            Products = x.ProductsSold.Where(p=>p.Buyer!=null)
                                .Select(p => new
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .ToList()
                        }
                })
                .OrderByDescending(x=>x.SoldProducts.Count)
                .ToList();

            return JsonConvert.SerializeObject(new { UsersCount = users.Count, Users = users }, Formatting.Indented);
        }
    }
}
