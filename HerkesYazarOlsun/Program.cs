using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Utils;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DbSettings.HerkesYazarOlsunDbContext = builder.Configuration.GetConnectionString("HerkesYazarOlsunDb2") ;

builder.Services.AddDbContext<HerkesyazarolsunContext>(options =>
{
    options.UseNpgsql(DbSettings.HerkesYazarOlsunDbContext
       // ,x => x.MigrationsAssembly("HerkesYazarOlsun.DataLayer")
    );
});


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
