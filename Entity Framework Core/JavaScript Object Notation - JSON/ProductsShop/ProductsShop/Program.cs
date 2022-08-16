using ProductsShop.Data;
using ProductsShop.Initializer;
using System;
using System.IO;

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

                var inputJson = File.ReadAllText($"{DatasetsDirectoryPath}/users.json");
            }
        }

        public static string ImportUsers(ProductsShopContext context, string inputJson)
        {
            return string.Empty;
        }
    }
}
