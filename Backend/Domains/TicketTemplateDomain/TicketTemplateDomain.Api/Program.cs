using Catut.Application.Configuration;
using Catut.Application.Extensions;
using Catut.Application.MediaRBehaviors;
using Catut.Application.Middlewares;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using TicketTemplateDomain.Api;
using TicketTemplateDomain.Api.Extensions;
using TicketTemplateDomain.Application;
using TicketTemplateDomain.Application.Services;
using TicketTemplateDomain.Infrastructure.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenApi.Account;
using TicketTemplateDomain.Api.Extensions.ServiceCollection;
using TicketTemplateDomain.Domain.Repositories;
using TicketTemplateDomain.Infrastructure.Repositories;
using ServiceCollectionExtensions = TicketTemplateDomain.Api.Extensions.ServiceCollectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;

configuration.AddJsonFile("Secrets/jwt.json");

var jwtConfig = configuration.GetConfiguration<JwtConfig>();
var apiConfig = configuration.GetConfiguration<ApiConfiguration>();

// ========= SERVICES  =========
var services = builder.Services;

services.Configure<ApiConfiguration>(configuration.GetSection(nameof(ApiConfiguration)));

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

services.AddAsymmetricAuthentication(jwtConfig);

services.InstallCors();
services.InstallSwagger();
services.InstallDbContext(configuration);
services.InstallMassTransit(configuration);

services.AddHttpContextAccessor();
services.AddTransient<IUserAccessor, UserAccessor>();
services.AddScoped<IDatabaseErrorMapper, DatabaseErrorMapper>();
services.AddScoped<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddApiHttpClinet<IAccountApi, AccountApi>(apiConfig);

services.AddScoped<ITicketTemplateRepository, TicketTemplateRepository>();

services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));
services.AddAuthorizationHandlers();

// ========= RUN  =========
var app = builder.Build();

if (!app.Environment.IsDevelopment())
    await app.MigrateDatabaseAsync<TicketTemplateDomainDbContext>();

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