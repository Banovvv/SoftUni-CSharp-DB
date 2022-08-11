using BookShopSystem.Initializer;
using BookShopSystem.Data;
using System;

namespace BookShopSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BookShopContext())
            {
                DbInitializer.ResetDatabase(context);
            }
        }
    }
}
