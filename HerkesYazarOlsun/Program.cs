using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Logging ayarlarý
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Logging.AddEventLog();
}
else
{
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole(); // Linux / Hosting ortamý için
}
 
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

// Validator’lar
builder.Services.AddScoped<BookDegerlendirmeValidator>();
builder.Services.AddScoped<BooksCommentValidator>();
builder.Services.AddScoped<UsersValidator>();
builder.Services.AddScoped<CheckBooksValidator>();
builder.Services.AddScoped<EmailValidator>();
builder.Services.AddScoped<BooksAddValidator>();
builder.Services.AddScoped<SmsValidator>();
builder.Services.AddScoped<BooksStarsValidator>();
builder.Services.AddScoped<BooksPagesAddValidator>();
builder.Services.AddScoped<AyarlarValidator>();

builder.Services.AddScoped<OdemeSponsorlariValidator>();
builder.Services.AddScoped<BooksPagesAddValidator>();
builder.Services.AddScoped<WriterFollowValidator>();
builder.Services.AddScoped<WriterStarsValidator>();


// DbSettings
DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb");
DbSettings.HerkesYazarOlsunDbSQL = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDb");
DbSettings.HerkesYazarOlsunSQLDbTest = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDbTest");
DbSettings.HerkesYazarOlsunDbSQLWindowsAuthentication = builder.Configuration.GetConnectionString("HerkesYazarOlsunDbSQLWindowsAuthentication");


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  


builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;//Preserve
        opt.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

InstanceFactory.Provider = app.Services;
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Path düzeltme middleware
app.Use((context, next) =>
{
    if (context.Request.Path.Value.StartsWith("//"))
    {
        context.Request.Path = new PathString(context.Request.Path.Value.Replace("//", "/"));
    }
    return next();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
