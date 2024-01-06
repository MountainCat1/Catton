using System.Security.Claims;
using Catut.Application.Errors;
using Microsoft.AspNetCore.Authorization;

namespace Catut.Application.Extensions;

public static class AuthorizationServiceExtensions
{
    public static async Task<AuthorizationResult> AuthorizeAndThrowAsync(
        this IAuthorizationService authorizationService,
        ClaimsPrincipal user,
        object? resource,
        string policy)
    {
        var authorizationResult = await authorizationService.AuthorizeAsync(user, resource, policy);
        
        if(authorizationResult.Succeeded)
            return authorizationResult;
        
        var failure = authorizationResult.Failure!;

        throw new UnauthorizedError(failure.FailureReasons);
    }
}