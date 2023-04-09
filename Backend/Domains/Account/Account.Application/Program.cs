using Account.Application;
using Account.Application.Extensions;
using Account.Application.Features.EmailPasswordAuthentication;
using Account.Application.Features.GoogleAuthentication;
using Account.Application.Services;
using Account.Application.Settings;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;

configuration.AddJsonFile("Secrets/authentication.json");
configuration.AddJsonFile("Secrets/jwt.json");

var jwtConfig = configuration.GetConfiguration<JwtConfig>();

// Add services to the container.

var services = builder.Services;

services.Configure<AuthenticationConfig>(configuration.GetSection(nameof(AuthenticationConfig)));
services.Configure<JwtConfig>(configuration.GetSection(nameof(JwtConfig)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddLogging();

services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", builder =>
    {
        builder.WithOrigins(new[]
            {
                "http://localhost:4200", // local frontend
                "https://localhost:5000", // local swagger 
                "http://localhost:4000", // local swagger
            })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("AccountDb"),  
        b => b.MigrationsAssembly(typeof(AssemlyMarker).Assembly.FullName));
});

services.AddScoped<IHashingService, HashingService>();
services.AddScoped<IJWTService, JWTService>();

services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IGoogleAccountRepository, GoogleAccountRepository>();
services.AddScoped<IPasswordAccountRepository, PasswordAccountRepository>();

services.AddScoped<IGoogleAuthProviderService, GoogleAuthProviderService>();
services.AddScoped<IPasswordAuthProviderService, PasswordAuthProviderService>();

services.AddAsymmetricAuthentication(jwtConfig);

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(AssemlyMarker).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();