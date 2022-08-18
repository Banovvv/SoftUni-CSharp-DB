using CarDealer.Data;
using System;

namespace CarDealer.Initializer
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
