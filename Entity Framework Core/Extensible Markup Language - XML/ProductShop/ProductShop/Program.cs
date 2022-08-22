using ProductShop.Data;
using ProductShop.Models.DTOs;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class Program
    {
        private const string DatasetsDirectoryPath = "../../../Datasets";
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";
        static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {
                //DbInitializer.Initialize(context);
                //DbInitializer.Seed(context);

                // 5. Products In Range
                //File.WriteAllText($"{ResultsDirectoryPath}/products-in-range.xml", GetProductsInRange(context));

                // 6. Sold Products
                //File.WriteAllText($"{ResultsDirectoryPath}/users-sold-products.xml", GetSoldProducts(context));

                // 7. Categories By Products Count
                File.WriteAllText($"{ResultsDirectoryPath}/categories-by-products.xml", GetCategoriesByProductsCount(context));
            }
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            IEnumerable<ProductsInRangeDTO> products = context.Products.Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductsInRangeDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ProductsInRangeDTO>), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, products, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            IEnumerable<UsersWithSoldProductsDTO> users = context.Users.Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UsersWithSoldProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new ProductSoldDTO
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList()
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<UsersWithSoldProductsDTO>), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, users, namespaces);
            }

            return sb.ToString().Trim();
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IEnumerable<CategoryByProductDTO> categories = context.Categories
                .Select(x => new CategoryByProductDTO
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts.Where(cp => cp.CategoryId == x.Id).Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Where(cp => cp.CategoryId == x.Id).Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<CategoryByProductDTO>), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            StringBuilder sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, categories, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}
