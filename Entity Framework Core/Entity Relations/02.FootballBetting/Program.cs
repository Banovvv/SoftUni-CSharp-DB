using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using(var context = new FootballBettingContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
