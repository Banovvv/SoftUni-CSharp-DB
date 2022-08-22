using ProductShop.Data;
using ProductShop.Initializer;
using ProductShop.Models;
using ProductShop.Models.DTOs;
using System;
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
                File.WriteAllText($"{ResultsDirectoryPath}/products-in-range.xml", GetProductsInRange(context));
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
    }
}
