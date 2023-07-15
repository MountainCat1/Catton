using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Authorization.Handlers;
using ConventionDomain.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Conventions.Api.Extensions.ServiceCollection;

public static class AuthorizationPoliciesDefiner
{
    public static IServiceCollection DefineAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, IsOrganizerOfHandler>();
        
        services.AddAuthorization(DefineAuthorizationPolicies);

        return services;
    }

    private static void DefineAuthorizationPolicies(AuthorizationOptions options)
    {
        // CONVENTION
        options.AddPolicyWithRequirements(Policies.ReadConvention, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        options.AddPolicyWithRequirements(Policies.UpdateConvention, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        // TICKET TEMPLATES
        options.AddPolicyWithRequirements(Policies.ReadTicketTemplates, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        options.AddPolicyWithRequirements(Policies.ManageTicketTemplates, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        // ORGANIZER
        options.AddPolicyWithRequirements(Policies.ReadOrganizer, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        options.AddPolicyWithRequirements(Policies.CreateOrganizer, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        options.AddPolicyWithRequirements(Policies.UpdateOrganizer, new IAuthorizationRequirement[]
        {
            new IsOrganizerOfRequirement()
        });
        
        options.AddPolicyWithRequirements(Policies.DeleteOrganizer, new IAuthorizationRequirement[]
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