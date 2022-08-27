using Microsoft.EntityFrameworkCore;
using SalesDatabase.Data;

namespace SalesDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SalesDataContext();
            context.Database.Migrate();
        }
    }
}
