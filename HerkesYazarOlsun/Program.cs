using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
if (OperatingSystem.IsWindows())
{
    builder.Logging.AddEventLog(); // Sadece Windows'ta etkin
}

// IHttpContextAccessor servis olarak ekleniyor:
builder.Services.AddHttpContextAccessor();


// Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var dbType = configuration["DbType"]; 

if (dbType == "Sql")
{
    builder.Services.AddDbContext<SqlServerContext>((serviceProvider, options) =>
    {
        options.UseSqlServer(configuration.GetConnectionString("HerkesYazarOlsunSQLDb"));
    });
}
else
{
    builder.Services.AddDbContext<HerkesYazaOlsunContext>((serviceProvider, options) =>
    {
        options.UseNpgsql(configuration.GetConnectionString("HerkesYazarOlsunDb"));
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
} 

// Repository ve servis kayýtlarý
builder.Services.AddScoped(typeof(SqlRepo<>));
builder.Services.AddScoped(typeof(BaseSqlDbContext), typeof(SqlServerContext));

builder.Services.AddScoped(typeof(NpgsqlRepo<>));
builder.Services.AddScoped(typeof(BaseNpSqlDbContext), typeof(HerkesYazaOlsunContext));

builder.Services.AddScoped(typeof(EfSqlEntityRepositoryBase<>));
builder.Services.AddScoped(typeof(EfNpSqlEntityRepositoryBase<>));

builder.Services.AddScoped(typeof(IRepo<>), typeof(HybridRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(RepositorySql<>));
builder.Services.AddScoped(typeof(RepositoryNpgsql<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(HybridRepository<>));

builder.Services.IoCDataAccessLayerRegister();
builder.Services.IoCBusinessLogicLayerRegister();

//InstanceFactory.Provider = builder.Services.BuildServiceProvider();

DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb");
DbSettings.HerkesYazarOlsunDbSQL = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDb");
DbSettings.HerkesYazarOlsunSQLDbTest = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDbTest");
DbSettings.HerkesYazarOlsunDbSQLWindowsAuthentication = builder.Configuration.GetConnectionString("HerkesYazarOlsunDbSQLWindowsAuthentication");



var app = builder.Build();

// Middleware ve routing ayarlarý

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use((context, next) =>
{
    if (context.Request.Path.Value.StartsWith("//"))
    {
        context.Request.Path = new PathString(context.Request.Path.Value.Replace("//", "/"));
    }
    return next();
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

 