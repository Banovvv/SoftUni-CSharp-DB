namespace CarDealer.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=CarDealer;Integrated Security=true;";
        }
    }
}
