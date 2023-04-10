using System.Security.Claims;
using Account.Application.Dtos.Responses;

namespace Account.Application.Features.GetClaims;

public class GetClaimsResponseDto
{
    public required IEnumerable<ClaimDto> Claims { get; set; }
}