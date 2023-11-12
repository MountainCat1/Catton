﻿using System.Threading.Channels;
using ConventionDomain.Application.Authorization.Requirements;
using Conventions.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Authorization.Handlers;

public class IsAtendeeOfHandler : AuthorizationHandler<IsAtendeeOfRequirement, Convention>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        IsAtendeeOfRequirement requirement,
        Convention resource)
    {
        // var accountId = context.User.GetUserId();
        //
        // if (resource.Atendees.All(x => x.AccountId != accountId))
        // {
        //     context.Fail();
        //     return;
        // }
        
        context.Succeed(requirement);
    }
}