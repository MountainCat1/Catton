using ConventionDomain.Application.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace Conventions.Api.Extensions;

public static class ServiceCollectionAuthorizationExtensions
{
    public static IServiceCollection AddResourceAuthorization(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, ConventionAuthorizationHandler>();

        return services;
    }
}