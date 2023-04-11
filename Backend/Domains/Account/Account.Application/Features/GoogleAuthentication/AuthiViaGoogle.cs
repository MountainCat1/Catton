using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Account.Service.Services;
using Google.Apis.Auth;
using LanguageExt.Common;

namespace Account.Service.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequestContract
{
    public required string AuthToken { get; set; }
}

public class AuthiViaGoogleRequest : IResultRequest<AuthTokenResponseContract>
{
    public required string GoogleAuthToken { get; set; }
}

public class AuthiViaGoogleRequestHandler : IResultRequestHandler<AuthiViaGoogleRequest, AuthTokenResponseContract>
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

    public async Task<Result<AuthTokenResponseContract>> Handle(AuthiViaGoogleRequest request, CancellationToken cancellationToken)
    {
        GoogleJsonWebSignature.Payload payload;
        try
        {
            payload = await _authProviderService.ValidateGoogleJwtAsync(request.GoogleAuthToken);
        }
        catch (Exception ex)
        {
            return new Result<AuthTokenResponseContract>(ex);
        }

        var account = await _accountRepository.GetOneRequiredAsync(account => account.Email == payload.Email);

        var jwt = _jwtService.GenerateAsymmetricJwtToken(account);

        return new AuthTokenResponseContract()
        {
            AuthToken = jwt
        };
    }
}