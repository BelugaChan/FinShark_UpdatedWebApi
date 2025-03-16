using api.Cache;
using api.Controllers;
using api.Data;
using api.Interfaces;
using api.Interfaces.Cache;
using api.Interfaces.Services;
using api.Repository;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IStockService, StockService>();

//Addin db
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

