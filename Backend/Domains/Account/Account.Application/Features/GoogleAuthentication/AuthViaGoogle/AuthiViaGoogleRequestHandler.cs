using System.Security.Claims;
using Account.Application.Abstractions;
using Account.Application.Dtos.Responses;
using Account.Application.Services;
using Account.Domain.Repositories;
using Google.Apis.Auth;
using LanguageExt.Common;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

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