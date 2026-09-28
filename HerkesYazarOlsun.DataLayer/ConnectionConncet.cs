using Microsoft.Extensions.Configuration;
namespace HerkesYazarOlsun.DataLayer;

public static class ConnectionConncet
{
    // Resolve the service project explicitly; never use a DataLayer appsettings file.
    public static string ServiceSettingsDirectory()
    {
        foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            for (var directory = new DirectoryInfo(start); directory != null; directory = directory.Parent)
            {
                foreach (var candidate in new[] { directory.FullName, Path.Combine(directory.FullName, "HerkesYazarOlsun") })
                    if (File.Exists(Path.Combine(candidate, "HerkesYazarOlsun.Service.csproj"))) return candidate;
            }
        }
        // Published service: configuration resides beside its assembly.
        if (File.Exists(Path.Combine(AppContext.BaseDirectory, "HerkesYazarOlsun.Service.dll")) &&
            File.Exists(Path.Combine(AppContext.BaseDirectory, "appsettings.json"))) return AppContext.BaseDirectory;
        throw new InvalidOperationException("Servis ayar dizini bulunamadı. EF komutunu HerkesYazarOlsun.Servis veya HerkesYazarOlsun dizininden çalıştırın.");
    }
    private static string GetConnection(string name)
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        var config = new ConfigurationBuilder().SetBasePath(ServiceSettingsDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables().Build();
        return config.GetConnectionString(name)
            ?? throw new InvalidOperationException($"Servis ayarlarında {name} bulunamadı.");
    }
    public static string GetSqlConnect() => GetConnection("HerkesYazarOlsunSQLDb");
    public static string GetPostgreSqlConnect() => GetConnection("HerkesYazarOlsunPostgreDb");
}
