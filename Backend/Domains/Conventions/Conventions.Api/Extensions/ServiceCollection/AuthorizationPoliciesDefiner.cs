using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Conventions.Api.Extensions.ServiceCollection;

public static class AuthorizationPoliciesDefiner
{
    public static IServiceCollection DefineAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(DefineAuthorizationPolicies);

        return services;
    }

    private static void DefineAuthorizationPolicies(AuthorizationOptions options)
    {
        options.AddPolicyWithRequirements(Policies.CreateOrganizerPolicy, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
    }

    private static void AddPolicyWithRequirements(
        this AuthorizationOptions policyBuilder,
        string policyName,
        IAuthorizationRequirement[] requirements)
    {
        policyBuilder.AddPolicy(policyName, builder =>
        {
            builder.AddRequirements(requirements);
        });
    }
}