using ConventionDomain.Api;
using ConventionDomain.Api.MediaRBehaviors;
using ConventionDomain.Api.Middlewares;
using ConventionDomain.Application;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Contexts;
using ConventionDomain.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ========= CONFIGURATION  =========
var configuration = builder.Configuration;


// ========= SERVICES  =========
var services = builder.Services;

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

services.AddDbContext<ConventionDomainDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConventionDomainDatabase"),  
        b => b.MigrationsAssembly(typeof(ApiAssemblyMarker).Assembly.FullName));
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
        .AddFilter((_, _) => false)
        .AddConsole()));
});


services.AddSingleton<ErrorHandlingMiddleware>();
services.AddFluentValidationAutoValidation();
services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(ApplicationAssemblyMarker).Assembly));

services.AddScoped<IConventionRepository, ConventionRepository>();

// ========= RUN  =========
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();