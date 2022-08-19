namespace ProductShop.Data
{
    internal class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=ProductShop;Integrated Security=true;";
        }
    }
}
