using System.Configuration;

namespace BookShopSystem.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return @"Server=.\SQLEXPRESS;Database=BookShop;Integrated Security=true;";
        }
    }
}
