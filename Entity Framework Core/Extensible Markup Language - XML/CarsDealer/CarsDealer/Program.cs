using CarsDealer.Data;
using CarsDealer.Initializer;

namespace CarsDealer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                DbInitializer.Initialize(context);
            }
        }
    }
}
