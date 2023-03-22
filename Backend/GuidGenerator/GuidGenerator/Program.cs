using System.Runtime.InteropServices.JavaScript;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Register Redis stuff

var redisConfiguration = new RedisConfiguration()
{
    AbortOnConnectFail = false,
    // Hosts = new RedisHost[]
    // {
    //     new RedisHost() { Host = "localhost", Port = 6379 },
    // },
    AllowAdmin = true,
    ConnectTimeout = 1000,
    Database = 0,
};

var configurationOptions = new ConfigurationOptions
{
    EndPoints = { "localhost:7001" },
    Password = "SUPER_SECRET_PASSWORD_123",
};

services.AddScoped<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configurationOptions));
services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var delay = serviceProvider.GetRequiredService<IConnectionMultiplexer>().GetDatabase().Ping();
    Console.WriteLine(delay);
}

app.Run();