using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Servis.Services;
using HerkesYazarOlsun.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Logging ayarlar�
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Logging.AddEventLog();
}
else
{
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole(); // Linux / Hosting ortam� i�in
}
 
// Swagger — Bearer token desteğiyle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HerkesYazarOlsun API", Version = "v1" });

    // Swagger'a Bearer auth butonu ekle
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name         = "Authorization",
        Type         = SecuritySchemeType.Http,
        Scheme       = "Bearer",
        BearerFormat = "JWT",
        In           = ParameterLocation.Header,
        Description  = "JWT token girin. Örnek: Bearer {token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// JWT ayarları
var jwtSection = builder.Configuration.GetSection("JwtSettings");
var secretKey  = jwtSection["SecretKey"]!;
var issuer     = jwtSection["Issuer"]!;
var audience   = jwtSection["Audience"]!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = true,
        ValidateAudience         = true,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer              = issuer,
        ValidAudience            = audience,
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew                = TimeSpan.Zero
    };
});

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
    builder.Services.AddDbContext<PostgreSqlContext>((serviceProvider, options) =>
    {
        options.UseNpgsql(configuration.GetConnectionString("HerkesYazarOlsunPostgreDb"));
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
}

// Repository ve servis kay�tlar�
builder.Services.AddScoped(typeof(SqlRepo<>));
builder.Services.AddScoped(typeof(BaseSqlDbContext), typeof(SqlServerContext));

builder.Services.AddScoped(typeof(NpgsqlRepo<>));
builder.Services.AddScoped(typeof(BaseNpSqlDbContext), typeof(PostgreSqlContext));

builder.Services.AddScoped(typeof(EfSqlEntityRepositoryBase<>));
builder.Services.AddScoped(typeof(EfNpSqlEntityRepositoryBase<>));

builder.Services.AddScoped(typeof(IRepo<>), typeof(HybridRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(RepositorySql<>));
builder.Services.AddScoped(typeof(RepositoryNpgsql<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(HybridRepository<>));

builder.Services.IoCDataAccessLayerRegister();
builder.Services.IoCBusinessLogicLayerRegister();

// Validator�lar
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
builder.Services.AddScoped<FavoriYazarlarValidator>();

// DbSettings
DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb");
DbSettings.HerkesYazarOlsunDbSQL = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDb");
DbSettings.HerkesYazarOlsunSQLDbTest = builder.Configuration.GetConnectionString("HerkesYazarOlsunSQLDbTest");
DbSettings.HerkesYazarOlsunDbSQLWindowsAuthentication = builder.Configuration.GetConnectionString("HerkesYazarOlsunDbSQLWindowsAuthentication");


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<JwtTokenService>();
/* CORS ayarlari
builder.Services.AddCors(options =>
{
    options.AddPolicy("herkesyazarolsun", policy =>
    {
        policy.WithOrigins("https://herkesyazarolsun.com.tr")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
*/
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

// Path duzeltme middleware
app.Use(async (context, next) =>
{
    if (!string.IsNullOrEmpty(context.Request.Path.Value) &&
        context.Request.Path.Value.StartsWith("//"))
    {
        context.Request.Path = new PathString(
            context.Request.Path.Value.Replace("//", "/"));
    }

    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// app.UseCors("herkesyazarolsun"); 
app.UseAuthentication(); // JWT doğrulama
app.UseAuthorization();
app.MapControllers();

app.Run();
