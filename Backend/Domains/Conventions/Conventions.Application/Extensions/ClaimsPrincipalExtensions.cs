using System.Security.Claims;

namespace Conventions.Application.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        return new Guid(claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.PrimarySid).Value);
    }
}