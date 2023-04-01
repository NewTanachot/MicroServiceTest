using MicroServiceTest.Data;
using MicroServiceTest.Interfaces;
using MicroServiceTest.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Db Service in DI
builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("default"));
});

//builder.Services.AddControllers();

// Add IgnoreCycles in JsonOption for Fix recursion of data access process (EF Core model)
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Essential Dependency Injection

// Controller is automaticly add HttpClient already but in Service is not. You need to add again
builder.Services.AddHttpClient();
// Add ProductService in DI
builder.Services.AddSingleton(typeof(IProductService<>), typeof(ProductService<>));
// Add AuthService in DI
builder.Services.AddSingleton<IAuthService, AuthService>();

// Use Serilog
builder.Host.UseSerilog((context, config) =>
{
    // Config from appsetting
    config.ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());

    // Dirty config
    //config.WriteTo.Console();
    //config.WriteTo.File(builder.Configuration.GetValue<string>("LoggerFilePath") ?? string.Empty);
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
