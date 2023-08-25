using System.Text.Json.Serialization;
using Catut.Application.Abstractions;
using Catut.Application.Configuration;
using Catut.Application.Extensions;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Application.Services;
using Catut.Infrastructure.Abstractions;
using ConventionDomain.Application;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Services;
using Conventions.Api.Extensions;
using Conventions.Api.Extensions.ServiceCollection;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using Conventions.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using OpenApi.Accounts;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========

#region Configuration

var configuration = builder.Configuration;

configuration.AddJsonFile("Secrets/jwt.json");

var jwtConfig = configuration.GetConfiguration<JwtConfig>();

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
    // loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
});

//  === INSTALLERS ===
services.InstallSwagger();
services.InstallMassTransit(configuration);
services.InstallCors();
services.InstallDbContext(configuration);
services.DefineAuthorizationPolicies();
//  ===            ===

services.AddAsymmetricAuthentication(jwtConfig);

services.AddApiHttpClinet<IAccountsApi, AccountsApi>();

services.AddScoped<IConventionRepository, ConventionRepository>();

services.AddHttpContextAccessor();
services.AddSingleton<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddSingleton<IApiExceptionMapper, ApiExceptionMapper>();
services.AddTransient<IUserAccessor, UserAccessor>();
services.AddTransient<IAuthTokenAccessor, AuthTokenAccessor>();
services.AddSingleton<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));

services.AddScoped<IConvenitonUnitOfWork, ConventionDomainUnitOfWork>();
services.AddScoped<ICommandMediator, ConventionCommandMediator>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion