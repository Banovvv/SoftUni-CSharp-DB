using Microsoft.EntityFrameworkCore;
using System;

namespace ProductShop.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("ProductShop database created.");
        }
    }
}
