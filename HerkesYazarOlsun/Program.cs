using HerkesYazarOlsun.BLL.Ioc;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.IoCDataAccessLayerRegister();
builder.Services.IoCBusinessLogicLayerRegister();


InstanceFactory.Provider = builder.Services.BuildServiceProvider();

DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb2") ;

/*
builder.Services.AddDbContext<HerkesYazaOlsunContext>(options =>
{
    options.UseNpgsql(DbSettings.HerkesYazarOlsunDbContext
       // ,x => x.MigrationsAssembly("HerkesYazarOlsun.DataLayer")
    );
});
*/
builder.Services.AddDbContext<HerkesYazaOlsunContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
