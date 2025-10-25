using Microsoft.Extensions.Configuration; 
namespace HerkesYazarOlsun.DataLayer
{    public static class ConnectionConncet
    {
        public static string GetSqlConnect()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            string baglanti = config.GetConnectionString("HerkesYazarOlsunSQLDb");
             

            return baglanti;
        }

        public static string GetPostgreSqlConnect()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            string baglanti = config.GetConnectionString("HerkesYazarOlsunPostgreDb"); 

            return baglanti;
        }
    }

}
