using Account.Application.Abstractions;
using Account.Application.Dtos.Responses;
using LanguageExt.Common;

namespace Account.Application.Features.GetClaims;

public class GetClaimsRequestHandler : IResultRequestHandler<GetClaimsRequest, GetClaimsResponseDto>
{
    public Task<Result<GetClaimsResponseDto>> Handle(GetClaimsRequest request, CancellationToken cancellationToken)
    {
        var responseDto = new GetClaimsResponseDto()
        {
            Claims = request.ClaimsPrincipal.Claims.Select(x => new ClaimDto(x.Type, x.Value))
        };
        
        return Task.FromResult<Result<GetClaimsResponseDto>>(responseDto);
    }
}