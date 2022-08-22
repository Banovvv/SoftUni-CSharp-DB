using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ProductShop.Initializer
{
    public class DbInitializer
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";

        public static void Initialize(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("ProductShop database created.");
        }

        public static void Seed(ProductShopContext context)
        {
            // 1. Import Users
            var users = File.ReadAllText($"{DatasetsDirectoryPath}/users.xml");
            Console.WriteLine(ImportUsers(context, users));

            // 2. Import Products
            var products = File.ReadAllText($"{DatasetsDirectoryPath}/products.xml");
            Console.WriteLine(ImportProducts(context, products));

            // 3. Import Categories
            var categories = File.ReadAllText($"{DatasetsDirectoryPath}/categories.xml");
            Console.WriteLine(ImportCategories(context, categories));

            // 4. Import Categories and Products
            var categoryProducts = File.ReadAllText($"{DatasetsDirectoryPath}/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(context, categoryProducts));
        }

        #region Import Functions
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(User[]), new XmlRootAttribute("Users"));

            var stringReader = new StringReader(inputXml);

            using (stringReader)
            {
                IEnumerable<User> users = (User[])serializer.Deserialize(stringReader);

                context.Users.AddRange(users);
                context.SaveChanges();

                return $"Successfully imported {users.Count()}";
            }
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Product[]), new XmlRootAttribute("Products"));

            var stringReader = new StringReader(inputXml);

            using (stringReader)
            {
                IEnumerable<Product> products = (Product[])serializer.Deserialize(stringReader);

                context.Products.AddRange(products);
                context.SaveChanges();

                return $"Successfully imported {products.Count()}";
            }
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Category[]), new XmlRootAttribute("Categories"));

            var stringReader = new StringReader(inputXml);

            using (stringReader)
            {
                IEnumerable<Category> categories = (Category[])serializer.Deserialize(stringReader);

                context.Categories.AddRange(categories);
                context.SaveChanges();

                return $"Successfully imported {categories.Count()}";
            }
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryProduct[]), new XmlRootAttribute("CategoryProducts"));

            var stringReader = new StringReader(inputXml);

            using (stringReader)
            {
                IEnumerable<CategoryProduct> categoryProducts = (CategoryProduct[])serializer.Deserialize(stringReader);

                foreach (var categoryProduct in categoryProducts)
                {
                    if (context.Products.Any(x => x.Id == categoryProduct.ProductId) && context.Categories.Any(x => x.Id == categoryProduct.CategoryId))
                    {
                        context.CategoryProduct.Add(categoryProduct);
                    }
                }

                context.SaveChanges();

                return $"Successfully imported {categoryProducts.Count()}";
            }
        }
        #endregion
    }
}
