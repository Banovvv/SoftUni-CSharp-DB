namespace CarsDealer.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=CarsDealer;Integrated Security=true;";
        }
    }
}
