using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Repositories;
using ProductManagementAPI.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Create and configure the Serilog logger by reading settings
// from appsettings.json, appsettings.Development.json, or
// appsettings.Production.json based on the current environment.
// This allows us to manage log levels, file sinks, and other logging behavior
// from configuration instead of hardcoding everything here.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

// Tell ASP.NET Core to use Serilog as the main logging provider
// instead of the default built-in logging providers.
builder.Host.UseSerilog();

builder.Services.AddControllers()
             .AddJsonOptions(options =>
             {
                 // Disable camelCase so JSON property names remain the same as C# property names
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
             });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ApplicationDbContext and configure it to use SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and service classes for dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

//Enabling Swagger for all environments, including production. This is useful for testing and debugging
//app.UseSwagger();
//app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Logs details about every HTTP request such as:
// request path, method, status code, and execution time.
// This helps a lot when troubleshooting production issues.
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
