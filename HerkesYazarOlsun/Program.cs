using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL
builder.Services.AddScoped(typeof(SqlRepo<>));
builder.Services.AddScoped(typeof(BaseSqlDbContext), typeof(SqlServerContext));

// PostgreSQL
builder.Services.AddScoped(typeof(NpgsqlRepo<>));
builder.Services.AddScoped(typeof(BaseNpSqlDbContext), typeof(HerkesYazaOlsunContext));

// SQL
builder.Services.AddScoped(typeof(EfSqlEntityRepositoryBase<>));
// PostgreSQL
builder.Services.AddScoped(typeof(EfNpSqlEntityRepositoryBase<>));

// Eðer hybrid kullanýlacaksa
builder.Services.AddScoped(typeof(IRepo<>), typeof(HybridRepo<>));

builder.Services.AddScoped(typeof(RepositorySql<>));
builder.Services.AddScoped(typeof(RepositoryNpgsql<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(HybridRepository<>)); 

builder.Services.IoCDataAccessLayerRegister();
builder.Services.IoCBusinessLogicLayerRegister();


InstanceFactory.Provider = builder.Services.BuildServiceProvider();

DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb");
DbSettings.HerkesYazarOlsunDbSQL = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDb");
DbSettings.HerkesYazarOlsunSQLDbTest = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDbTest");
DbSettings.HerkesYazarOlsunDbSQLWindowsAuthentication = builder.Configuration.GetConnectionString("HerkesYazarOlsunDbSQLWindowsAuthentication");


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

 

builder.Services.AddDbContext<HerkesYazaOlsunContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
