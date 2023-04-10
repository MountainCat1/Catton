using Account.Service.Dtos.Responses;

namespace Account.Service.Features.GetClaims;

public class GetClaimsResponseDto
{
    public required IEnumerable<ClaimDto> Claims { get; set; }
}