using Account.Application;
using Account.Application.Features.GoogleAuthentication;
using Account.Application.Services;
using Account.Application.Settings;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;


configuration.AddJsonFile("Secrets/authentication.json");
var authenticationSettings = new AuthenticationSettings();
configuration.GetSection("AuthenticationSettings").Bind(authenticationSettings);

// Add services to the container.

var services = builder.Services;

services.AddSingleton<AuthenticationSettings>(authenticationSettings);

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
    options.UseInMemoryDatabase("AccountDb");
});

services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IGoogleAccountRepository, GoogleAccountRepository>();


services.AddScoped<IGoogleAuthProviderService, GoogleAuthProviderService>();

services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = authenticationSettings.Google.ClientId;
        googleOptions.ClientSecret = authenticationSettings.Google.ClientSecret;
        googleOptions.ClaimsIssuer = "https://accounts.google.com";
    })
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.SecurityTokenValidators.Clear();
        jwtBearerOptions.SecurityTokenValidators.Add(new GoogleTokenValidator(authenticationSettings.Google.ClientSecret));
    });


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