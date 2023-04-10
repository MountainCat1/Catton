using System.Security.Claims;
using Account.Application.Abstractions;

namespace Account.Application.Features.GetClaims;

public class GetClaimsRequest : IResultRequest<GetClaimsResponseDto>
{
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    public GetClaimsRequest(ClaimsPrincipal claimsPrincipal)
    {
        ClaimsPrincipal = claimsPrincipal;
    }
}