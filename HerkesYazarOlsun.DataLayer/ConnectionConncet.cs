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

            //"Server=localhost\\SQLEXPRESS;Database=HERKESYAZAROLSUN_TEST;User Id=sa;Password=1234;TrustServerCertificate=True;";
            //"Server=localhost\\SQLEXPRESS;Database=HERKESYAZAROLSUN;User Id=sa;Password=1234;TrustServerCertificate=True;"

            return baglanti;
        }

        public static string GetPostgreSqlConnect()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            string baglanti = config.GetConnectionString("HerkesYazarOlsunDb"); 

            return baglanti;
        }
    }

}
