using Account.Application;
using Account.Application.Extensions;
using Account.Domain.Repositories;
using Account.Domain.Services;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Repositories;
using Account.Service;
using Account.Service.Features.EmailPasswordAuthentication;
using Account.Service.Features.GoogleAuthentication;
using Account.Service.Services;
using Account.Service.Settings;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Configuration;
using Catut.Infrastructure.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
    loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
});

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
    
        
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
        .AddFilter((category, level) => false)
        .AddConsole()));
});

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ServiceAssemlyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IGoogleAccountRepository, GoogleAccountRepository>();
services.AddScoped<IPasswordAccountRepository, PasswordAccountRepository>();

services.AddScoped<IPasswordAccountService, PasswordAccountService>();

services.AddScoped<IHashingService, HashingService>();
services.AddScoped<IJwtService, JwtService>();
services.AddScoped<IDatabaseErrorMapper, DatabaseErrorMapper>();

services.AddScoped<IGoogleAuthProviderService, GoogleAuthProviderService>();
services.AddScoped<IPasswordAuthProviderService, PasswordAuthProviderService>();

services.AddAsymmetricAuthentication(jwtConfig);

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ServiceAssemlyMarker).Assembly));

services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    await app.MigrateDatabaseAsync<AccountDbContext>();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("ENABLE_SWAGGER"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();