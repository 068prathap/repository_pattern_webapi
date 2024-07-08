using RepositoryPatternWebAPI.Services.WeatherForecastService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPatternWebAPI.Data;
using RepositoryPatternWebAPI.Models;
using RepositoryPatternWebAPI.Services.EmployeeListService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RepositoryPatternWebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RepositoryPatternWebAPIContext") ?? throw new InvalidOperationException("Connection string 'RepositoryPatternWebAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IEmployeeListService, EmployeeListService>();

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
