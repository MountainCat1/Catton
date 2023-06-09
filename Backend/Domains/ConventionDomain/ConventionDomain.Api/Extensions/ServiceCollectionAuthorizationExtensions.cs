using ConventionDomain.Application.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Api.Extensions;

public static class ServiceCollectionAuthorizationExtensions
{
    public static IServiceCollection AddResourceAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
        });

        services.AddSingleton<IAuthorizationHandler, ConventionAuthorizationHandler>();


        return services;
    }
}