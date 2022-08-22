using ProductShop.Data;
using ProductShop.Initializer;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                DbInitializer.Initialize(context);
                DbInitializer.Seed(context);                
            }
        }
    }
}
