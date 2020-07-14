using Microsoft.Extensions.Configuration;
using System.IO;

namespace Restaurant.Infra.Configuration
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
        }

        public static string GetConnection()
        {
            return ConnectionConfiguration.GetConnectionString("SqlServer");
        }
    }
}
