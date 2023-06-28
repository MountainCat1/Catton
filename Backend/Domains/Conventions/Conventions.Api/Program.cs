using System.Text.Json.Serialization;
using Catut.Application.Configuration;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Infrastructure.Abstractions;
using ConventionDomain.Application;
using ConventionDomain.Application.Services;
using Conventions.Api;
using Conventions.Api.Extensions;
using Conventions.Api.Extensions.ServiceCollection;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using Conventions.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceCollectionExtensions = Conventions.Api.Extensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;

configuration.AddJsonFile("Secrets/jwt.json");

var jwtConfig = configuration.GetConfiguration<JwtConfig>();

// ========= SERVICES  =========
var services = builder.Services;

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
    loggingBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
});

//  === INSTALLERS ===
services.InstallSwagger();
services.InstallMassTransit(configuration);
services.InstallCors();
services.InstallDbContext(configuration);
//  ===            ===

services.AddAsymmetricAuthentication(jwtConfig);

services.AddHttpContextAccessor();
services.AddSingleton<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddTransient<IUserAccessor, UserAccessor>();
services.AddSingleton<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));

services.AddScoped<IConventionRepository, ConventionRepository>();
services.AddScoped<IOrganizerRepository, OrganizerRepository>();

// ========= RUN  =========
var app = builder.Build();

if (!app.Environment.IsDevelopment())
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