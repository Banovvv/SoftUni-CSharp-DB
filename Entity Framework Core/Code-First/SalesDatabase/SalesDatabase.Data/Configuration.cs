namespace SalesDatabase.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=SalesDatabase;Integrated Security=true;";
        }
    }
}
