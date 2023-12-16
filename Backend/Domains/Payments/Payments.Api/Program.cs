using System.Text.Json.Serialization;
using Payments.Api.Extensions;
using Payments.Api.Installers;
using Payments.Application;
using Payments.Application.Authorization.Extensions;
using Payments.Application.Services;
using Payments.Infrastructure.Contexts;
using Catut.Application.Abstractions;
using Catut.Application.Configuration;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Application.Services;
using Catut.Infrastructure.Abstractions;
using FluentValidation;
using FluentValidation.AspNetCore;
using HashidsNet;
using MediatR;
using Payments.Application.Configuration;
using Payments.Application.Services.Domain;
using Payments.Domain.Repositories;
using Payments.Domain.Services;
using Payments.Infrastructure.Repositories;

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
    configuration.AddJsonFile("Secrets/stripe.json");
}


var jwtConfig = configuration.GetSecret<JwtConfig>();
var hashIdsConfig = configuration.GetSecret<HashIdsConfig>();

#endregion

// ========= SERVICES  =========

#region Services

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
    loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
});


services.Configure<ApiConfiguration>(configuration.GetSection(nameof(ApiConfiguration)));
services.Configure<StripeSettings>(configuration.GetSection(nameof(StripeSettings)));

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


services.AddScoped<IPaymentRepository, PaymentRepository>();

services.AddScoped<IPaymentService, PaymentService>();
services.AddScoped<IPaymentCommandMediator, PaymentCommandMediator>();
services.AddScoped<ISessionDomainService, SessionDomainService>();

services.AddScoped<IPaymentUnitOfWork, PaymentUnitOfWork>();
services.AddScoped<ICommandMediator, PaymentCommandMediator>();
services.AddScoped<IQueryMediator, QueryMediator>();

#endregion

// ========= RUN  =========
var app = builder.Build();

if (app.Configuration.GetValue<bool>("MIGRATE"))
    await app.MigrateDatabaseAsync<PaymentsDbContext>();

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

if (!app.Environment.IsDevelopment())
    app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();