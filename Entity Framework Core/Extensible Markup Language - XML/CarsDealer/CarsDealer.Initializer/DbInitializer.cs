using CarsDealer.Data;
using System;

namespace CarsDealer.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("CarDealer database created successfully.");
        }
    }
}
