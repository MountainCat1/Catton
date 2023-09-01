using ConventionDomain.Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Authorization.Handlers;

public class AlwaysPassHandler : AuthorizationHandler<AlwaysPassRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AlwaysPassRequirement requirement)
    {
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}