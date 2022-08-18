using CarDealer.Data;
using CarDealer.Initializer;
using System;

namespace CarDealer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new CarDealerContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
