using ProductsShop.Data;
using ProductsShop.Initializer;
using System;

namespace ProductsShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProductsShopContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
