using System.Security.Claims;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Catut;
using MediatR;

namespace Account.Service.Features.GetClaims;

public class GetClaimsRequest : IRequest<GetClaimsResponseDto>
{
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    public GetClaimsRequest(ClaimsPrincipal claimsPrincipal)
    {
        ClaimsPrincipal = claimsPrincipal;
    }
}

public class GetClaimsRequestHandler : IRequestHandler<GetClaimsRequest, GetClaimsResponseDto>
{
    public Task<GetClaimsResponseDto> Handle(GetClaimsRequest request, CancellationToken cancellationToken)
    {
        var responseDto = new GetClaimsResponseDto()
        {
            Claims = request.ClaimsPrincipal.Claims.Select(x => new ClaimDto(x.Type, x.Value))
        };

        return Task.FromResult(responseDto);
    }
}

public class GetClaimsResponseDto
{
    public required IEnumerable<ClaimDto> Claims { get; set; }
}