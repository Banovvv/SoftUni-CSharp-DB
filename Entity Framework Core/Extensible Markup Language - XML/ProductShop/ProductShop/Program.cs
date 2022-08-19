using ProductShop.Data;
using ProductShop.Initializer;
using System;

namespace ProductShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            using(var context = new ProductShopContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
