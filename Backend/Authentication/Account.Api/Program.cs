using Account.Api;
using Account.Api.Features.GoogleAuthentication;
using Account.Api.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;


configuration.AddJsonFile("Secrets/authentication.json");
var authenticationSettings = new AuthenticationSettings();
configuration.GetSection("AuthenticationSettings").Bind(authenticationSettings);

// Add services to the container.

var services = builder.Services;

services.AddSingleton<AuthenticationSettings>(authenticationSettings);

services.AddLogging();

services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", builder =>
    {
        builder.WithOrigins(new string[]
            {
                "http://localhost:4200", // local frontend
                "https://localhost:5000", // local swagger 
                "http://localhost:4000", // local swagger
            })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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
        googleOptions.ClientId = "934344019711-htpk4uv143hibkpol9vka7fk9qaasq86.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
        googleOptions.ClaimsIssuer = "https://accounts.google.com";
    })
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.SecurityTokenValidators.Clear();
        jwtBearerOptions.SecurityTokenValidators.Add(new GoogleTokenValidator("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"));
    });

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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