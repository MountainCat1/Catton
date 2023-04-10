using System.Security.Claims;
using Account.Service.Abstractions;

namespace Account.Service.Features.GetClaims;

public class GetClaimsRequest : IResultRequest<GetClaimsResponseDto>
{
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    public GetClaimsRequest(ClaimsPrincipal claimsPrincipal)
    {
        ClaimsPrincipal = claimsPrincipal;
    }
}