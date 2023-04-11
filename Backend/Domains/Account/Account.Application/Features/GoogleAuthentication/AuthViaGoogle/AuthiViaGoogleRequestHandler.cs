using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Account.Service.Services;
using Google.Apis.Auth;
using LanguageExt.Common;

namespace Account.Service.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequestHandler : IResultRequestHandler<AuthiViaGoogleRequest, AuthTokenResponseDto>
{
    private IAccountRepository _accountRepository;
    private IGoogleAuthProviderService _authProviderService;
    private IJwtService _jwtService;

    public AuthiViaGoogleRequestHandler(
        IAccountRepository accountRepository,
        IGoogleAuthProviderService authProviderService,
        IJwtService jwtService)
    {
        _accountRepository = accountRepository;
        _authProviderService = authProviderService;
        _jwtService = jwtService;
    }

    public async Task<Result<AuthTokenResponseDto>> Handle(AuthiViaGoogleRequest request, CancellationToken cancellationToken)
    {
        GoogleJsonWebSignature.Payload payload;
        try
        {
            payload = await _authProviderService.ValidateGoogleJwtAsync(request.GoogleAuthToken);
        }
        catch (Exception ex)
        {
            return new Result<AuthTokenResponseDto>(ex);
        }

        var account = await _accountRepository.GetOneRequiredAsync(account => account.Email == payload.Email);

        var jwt = _jwtService.GenerateAsymmetricJwtToken(account);

        return new AuthTokenResponseDto()
        {
            AuthToken = jwt
        };
    }
}