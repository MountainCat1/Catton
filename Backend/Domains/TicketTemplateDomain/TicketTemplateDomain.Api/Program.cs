using TicketTemplateDomain.Api;
using TicketTemplateDomain.Api.Extensions;
using TicketTemplateDomain.Api.MediaRBehaviors;
using TicketTemplateDomain.Api.Middlewares;
using TicketTemplateDomain.Application;
using TicketTemplateDomain.Application.Configuration;
using TicketTemplateDomain.Application.Services;
using TicketTemplateDomain.Infrastructure.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;

configuration.AddJsonFile("Secrets/jwt.json");

var jwtConfig = configuration.GetConfiguration<JwtConfig>();

// ========= SERVICES  =========
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(o =>
{
    o.AddSwaggerAuthUi();
});
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

services.AddAsymmetricAuthentication(jwtConfig);

services.AddDbContext<TicketTemplateDomainDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("TicketTemplateDomainDatabase"),
        b => b.MigrationsAssembly(typeof(ApiAssemblyMarker).Assembly.FullName));
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
        .AddFilter((_, _) => false)
        .AddConsole()));
});

services.AddHttpContextAccessor();
services.AddTransient<IUserAccessor, UserAccessor>();
services.AddSingleton<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

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