using CarsDealer.Data;
using CarsDealer.Initializer;
using CarsDealer.Models;
using CarsDealer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarsDealer
{
    internal class Program
    {
        private const string ResultsDirectoryPath = "../../../Datasets/Exports";

        static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                DbInitializer.Initialize(context);
                DbInitializer.Seed(context);
            }
        }
    }
}
