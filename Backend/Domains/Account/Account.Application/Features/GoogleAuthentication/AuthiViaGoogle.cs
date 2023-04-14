using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Account.Service.Errors;
using Account.Service.Services;
using Catton.Utilities;
using Google.Apis.Auth;

namespace Account.Service.Features.GoogleAuthentication;

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
        return 
            await ValidateGoogleJwt(request)
            .BindAsync(GetAccount)
            .BindAsync(GenerateJwt)
            .BindAsync(CreateResponseDto);
    }

    private async Task<Result<AuthTokenResponseContract>> CreateResponseDto(string jwt)
    {
        return new AuthTokenResponseContract()
        {
            AuthToken = jwt
        };
    }

    private async Task<Result<string>> GenerateJwt(AccountEntity accountEntity)
    {
        return _jwtService.GenerateAsymmetricJwtToken(accountEntity);
    }
    private async Task<Result<AccountEntity>> GetAccount(GoogleJsonWebSignature.Payload payload)
    {
        return await _accountRepository.GetAccountByEmailAsync(payload.Email) ?? Result<AccountEntity>.Failure(new NotFoundError());
    }

    private async Task<Result<GoogleJsonWebSignature.Payload>> ValidateGoogleJwt(AuthiViaGoogleRequest request)
    {
        GoogleJsonWebSignature.Payload payload;
        payload = await _authProviderService.ValidateGoogleJwtAsync(request.GoogleAuthToken);
        return payload;
    }
}