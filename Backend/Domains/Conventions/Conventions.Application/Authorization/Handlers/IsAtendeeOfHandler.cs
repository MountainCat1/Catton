using ConventionDomain.Application.Authorization.Requirements;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Authorization.Handlers;

public class IsAtendeeOfHandler : AuthorizationHandler<IsAtendeeOfRequirement, Convention>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        IsAtendeeOfRequirement requirement,
        Convention resource)
    {
        var accountId = context.User.GetUserId();
        
        if (resource.Attendees.All(x => x.AccountId != accountId))
        {
            context.Fail();
            return Task.CompletedTask;
        }
        
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}