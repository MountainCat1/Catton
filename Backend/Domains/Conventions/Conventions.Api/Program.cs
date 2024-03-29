using System.Text.Json.Serialization;
using Catut.Application.Abstractions;
using Catut.Application.Configuration;
using Catut.Application.Extensions;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Application.Services;
using Catut.Infrastructure.Abstractions;
using ConventionDomain.Application;
using ConventionDomain.Application.Authorization.Extensions;
using ConventionDomain.Application.DomainServices;
using ConventionDomain.Application.Services;
using Conventions.Api.Extensions;
using Conventions.Api.Extensions.ServiceCollection;
using Conventions.Domain.Repositories;
using Conventions.Domain.Services;
using Conventions.Infrastructure.Contexts;
using Conventions.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using HashidsNet;
using MediatR;
using OpenApi.Accounts;
using OpenApi.Payments;

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

// ========= SERVICES  =========

#region Services

var services = builder.Services;

services.Configure<ApiConfiguration>(configuration.GetSection(nameof(ApiConfiguration)));

services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});
services.AddEndpointsApiExplorer();
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

//  === INSTALLERS ===
services.InstallSwagger();
services.InstallMassTransit(configuration);
services.InstallCors();
services.InstallDbContext(configuration);
services.DefineAuthorizationPolicies();
//  ===            ===

services.AddAsymmetricAuthentication(jwtConfig);
services.AddSingleton<IHashids, Hashids>(x => new Hashids(hashIdsConfig.Salt, hashIdsConfig.MinHashLenght));

services.AddApiHttpClinet<IAccountsApi, AccountsApi>();
services.AddApiHttpClinet<IPaymentsApi, PaymentsApi>();

services.AddScoped<IConventionRepository, ConventionRepository>();

services.AddHttpContextAccessor();
services.AddSingleton<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddSingleton<IApplicationErrorMapper, ApplicationErrorMapper>();
services.AddSingleton<IApiExceptionMapper, ApiExceptionMapper>();
services.AddSingleton<IDomainErrorMapper, DomainErrorMapper>();
services.AddTransient<IUserAccessor, UserAccessor>();
services.AddTransient<IAuthTokenAccessor, AuthTokenAccessor>();
services.AddSingleton<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));

services.AddScoped<IConvenitonUnitOfWork, ConventionDomainUnitOfWork>();
services.AddScoped<ICommandMediator, ConventionCommandMediator>();
services.AddScoped<IQueryMediator, QueryMediator>();

services.AddScoped<IPaymentDomainService, PaymentDomainService>();

#endregion

// ========= BUILD =========

#region Build

var app = builder.Build();

if (app.Configuration.GetValue<bool>("MIGRATE_DATABASE"))
    await app.MigrateDatabaseAsync<ConventionDomainDbContext>();

if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("ENABLE_SWAGGER"))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

        // Enable JWT authentication in Swagger UI
        c.OAuthClientId("swagger");
        c.OAuthAppName("Swagger UI");
    });
}


app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowOrigins");

if (app.Configuration.GetValue<bool>("HTTPS_REDIRECT"))
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion