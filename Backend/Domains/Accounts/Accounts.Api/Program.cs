using Accounts.Application.Extensions;
using Accounts.Application.Extensions.ServiceCollection;
using Accounts.Domain.Repositories;
using Accounts.Infrastructure.Contexts;
using Accounts.Infrastructure.Repositories;
using Accounts.Service;
using Accounts.Service.Features.GoogleAuthentication;
using Accounts.Service.Services;
using Catut.Application.Abstractions;
using Catut.Application.Configuration;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Application.Services;
using Catut.Infrastructure.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
#region Configuration

var configuration = builder.Configuration;

if (configuration.GetRequiredEnvironmentVariable<bool>("USE_BLOB_CONFIGURATION"))
{
    Console.WriteLine("Loading configuration from Azure Blob Storage...");
    configuration.AddAzureBlobJsonConfiguration(new BlobStorageConfig()
    {
        ConnectionString = configuration.GetRequiredConnectionString("AzureBlobStorage"),
        ContainerName = configuration.GetRequiredEnvironmentVariable<string>("AZURE_BLOB_STORAGE_CONTAINER_NAME")
    }, "appsettings.json");
}

if (configuration.GetRequiredEnvironmentVariable<bool>("USE_AZURE_KEY_VAULT"))
{
    Console.WriteLine("Loading secrets from Azure Key Vault...");
    configuration.InstallAzureSecrets();
}
else
{
    Console.WriteLine("Loading secrets from local files...");
    configuration.AddJsonFile("Secrets/jwt.json");
    configuration.AddJsonFile("Secrets/hash_ids.json");
}


var jwtConfig = configuration.GetSecret<JwtConfig>();
var hashIdsConfig = configuration.GetSecret<HashIdsConfig>();

#endregion

// Add services to the container.

var services = builder.Services;

services.Configure<AuthenticationConfig>(configuration.GetSection(nameof(AuthenticationConfig)));
services.Configure<JwtConfig>(configuration.GetSection(nameof(JwtConfig)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
    loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
});

//  === INSTALLERS ===
services.InstallSwagger();
services.InstallMassTransit(configuration);
services.InstallCors();
services.InstallDbContext(configuration);
//  ===            ===

services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ServiceAssemlyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddSingleton<IApiExceptionMapper, ApiExceptionMapper>();
services.AddSingleton<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddSingleton<IApplicationErrorMapper, ApplicationErrorMapper>();

services.AddScoped<IAccountRepository, AccountRepository>();
services.AddScoped<IGoogleAccountRepository, GoogleAccountRepository>();
services.AddScoped<IPasswordAccountRepository, PasswordAccountRepository>();

services.AddScoped<IHashingService, HashingService>();
services.AddScoped<IJwtService, JwtService>();
services.AddScoped<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddHttpContextAccessor();
services.AddScoped<IUserAccessor, UserAccessor>();

services.AddScoped<IGoogleAuthProviderService, GoogleAuthProviderService>();

services.AddAsymmetricAuthentication(jwtConfig);

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ServiceAssemlyMarker).Assembly));

services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

if (app.Configuration.GetValue<bool>("MIGRATE_DATABASE"))
    await app.MigrateDatabaseAsync<AccountDbContext>();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("ENABLE_SWAGGER"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowOrigins");

if (app.Configuration.GetValue<bool>("HTTPS_REDIRECT"))
    app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();