using System.Configuration;

namespace BookShopSystem.Data
{
    internal static class Configuration
    {
        internal static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BookShopConnectionString"].ConnectionString;
        }
    }
}
