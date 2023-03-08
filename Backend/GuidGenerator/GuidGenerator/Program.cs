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
    Hosts = new RedisHost[]
    {
        new RedisHost() { Host = "localhost", Port = 6379 },
        new RedisHost() { Host = "localhost", Port = 54 }
    },
    AllowAdmin = true,
    ConnectTimeout = 5000,
    Database = 0,
};

services.AddScoped<IConnectionMultiplexer>(_
    => ConnectionMultiplexer.Connect($"{"localhost"},password={"SUPER_SECRET_PASSWORD_123"}"));
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

app.Run();