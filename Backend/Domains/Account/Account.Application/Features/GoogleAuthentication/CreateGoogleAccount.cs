using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using LanguageExt;
using LanguageExt.Common;

namespace Account.Service.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequestContract
{
    public required string AuthToken { get; set; }
}

public class CreateGoogleAccountRequest : IResultRequest
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}

public class CreateGoogleAccountRequestHandler : IResultRequestHandler<CreateGoogleAccountRequest>
{
    private readonly IGoogleAccountRepository _googleAccountRepository;
    private readonly IGoogleAuthProviderService _googleService;
    
    public CreateGoogleAccountRequestHandler(IGoogleAccountRepository googleAccountRepository, IGoogleAuthProviderService googleService)
    {
        _googleAccountRepository = googleAccountRepository;
        _googleService = googleService;
    }

    public async Task<Result<Unit>> Handle(CreateGoogleAccountRequest request, CancellationToken cancellationToken)
    {
        var googleTokenPayload = await _googleService.ValidateGoogleJwtAsync(request.GoogleAuthToken);

        var googleAccount = new GoogleAccountEntity(
            email: googleTokenPayload.Email,
            username: googleTokenPayload.Name
        );

        await _googleAccountRepository.AddAsync(googleAccount);
        
        var dbException = await _googleAccountRepository.SaveChangesAsync();

        if (dbException is not null)
            return new Result<Unit>(dbException);
        
        return new Result<Unit>();
    }
}