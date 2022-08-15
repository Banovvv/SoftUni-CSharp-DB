namespace ProductsShop.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=ProductsShop;Integrated Security=true;";
        }
    }
}
