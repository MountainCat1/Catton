using ConventionDomain.Application.Authorization.Requirements;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Authorization.Handlers;

public class IsOrganizerOfHandler : AuthorizationHandler<IsOrganizerOfRequirement, Convention>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        IsOrganizerOfRequirement requirement,
        Convention resource)
    {
        var accountId = context.User.GetUserId();
        
        if (resource.Organizers.All(x => x.AccountId != accountId))
        {
            context.Fail();
            return;
        }
        
        context.Succeed(requirement);
    }
}