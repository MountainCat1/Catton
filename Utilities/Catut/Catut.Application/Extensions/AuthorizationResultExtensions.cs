using Catut.Application.Errors;
using Microsoft.AspNetCore.Authorization;

namespace Catut.Application.Extensions;

public static class AuthorizationResultExtensions
{
    public static void ThrowIfFailed(this AuthorizationResult authorizationResult)
    {
        if(authorizationResult.Succeeded)
            return;
        
        var failure = authorizationResult.Failure!;

        throw new UnauthorizedError(failure.FailureReasons);
    }
}