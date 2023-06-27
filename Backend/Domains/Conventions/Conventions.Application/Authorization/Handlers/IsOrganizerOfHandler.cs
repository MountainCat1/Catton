using System.Security.Claims;
using Conventions.Application.Authorization.Requirements;
using Conventions.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Conventions.Application.Authorization.Handlers;

public class IsOrganizerOfHandler : AuthorizationHandler<IsOrganizerOfRequirement, Convention>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        IsOrganizerOfRequirement requirement,
        Convention resource)
    {
        var accountIdString = context.User.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value;
        var accountId = new Guid(accountIdString);

        
        if (!resource.Organizers.Any(x => x.AccountId == accountId))
        {
            context.Fail();
            return;
        }
        
        context.Succeed(requirement);
    }
}