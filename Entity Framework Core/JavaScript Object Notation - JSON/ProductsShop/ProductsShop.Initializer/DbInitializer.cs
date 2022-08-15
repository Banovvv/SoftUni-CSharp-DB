using ProductsShop.Data;
using System;

namespace ProductsShop.Initializer
{
    public class DbInitializer
    {
        public static void Initialize(ProductsShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("ProductsShop database created successfully.");
        }
    }
}
