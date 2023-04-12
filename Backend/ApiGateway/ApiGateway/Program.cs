using ApiGateway.Middleware;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// =======================================
// ===== CONFIGURATION =====
 
var configuration = builder.Configuration;

// Add all json ocelot configuration files 
string ocelotConfigDirectory = Path.Combine(Directory.GetCurrentDirectory(), "configuration");
string[] jsonFiles = Directory.GetFiles(ocelotConfigDirectory, "*.json", SearchOption.AllDirectories);

foreach (string jsonFile in jsonFiles)
{
    configuration.AddJsonFile(jsonFile, optional: true, reloadOnChange: true);
}

// Add all JSON files in the current directory and its subdirectories
configuration.AddJsonFile("*.json", optional: true, reloadOnChange: true);

// =======================================
// ===== SERVICES =====

var services = builder.Services;

services.AddControllers();
services.AddOcelot(configuration);
services.AddSingleton<ApiFallbackMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSwaggerForOcelot(configuration);

// =======================================
// ===== APP RUN =====

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

// app.UseMiddleware<ApiFallbackMiddleware>();

app.UseOcelot().Wait();

app.Run();