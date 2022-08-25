using HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new HospitalDataContext();
            context.Database.Migrate();
        }
    }
}
