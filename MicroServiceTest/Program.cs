using MicroServiceTest.Interfaces;
using MicroServiceTest.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Essential Dependency Injection

// Controller is automaticly add HttpClient already but ni Service is not. You need to add again
builder.Services.AddHttpClient();
// Add ProductService in DI
builder.Services.AddSingleton(typeof(IProductService<>), typeof(ProductService<>));
// Add AuthService in DI
builder.Services.AddSingleton<IAuthService, AuthService>();

// Use Serilog
builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
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
