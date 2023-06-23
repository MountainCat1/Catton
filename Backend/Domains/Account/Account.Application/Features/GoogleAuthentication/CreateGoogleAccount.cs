using Account.Domain.Entities;
using Account.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Account.Service.Features.GoogleAuthentication;

public class CreateGoogleAccountRequestContract
{
    public required string AuthToken { get; set; }
}

public class CreateGoogleAccountRequest : IRequest
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}

public class CreateGoogleAccountRequestHandler : IRequestHandler<CreateGoogleAccountRequest>
{
    private readonly IGoogleAccountRepository _googleAccountRepository;
    private readonly IGoogleAuthProviderService _googleService;

    public CreateGoogleAccountRequestHandler(IGoogleAccountRepository googleAccountRepository,
        IGoogleAuthProviderService googleService)
    {
        _googleAccountRepository = googleAccountRepository;
        _googleService = googleService;
    }

    public async Task Handle(CreateGoogleAccountRequest request, CancellationToken cancellationToken)
    {
        var googleTokenPayload = await _googleService.ValidateGoogleJwtAsync(request.GoogleAuthToken);

        // to refactor, should go to separate validator
        if (await _googleAccountRepository.GetAccountByEmailAsync(googleTokenPayload.Email) is not null)
        {
            throw new ValidationException("Email has already been taken", new[]
            {
                new ValidationFailure(nameof(GoogleAccountEntity.Email), "Email has already been taken")
            });
        }
        
        var googleAccountEntity = new GoogleAccountEntity(
            email: googleTokenPayload.Email,
            username: googleTokenPayload.Name
        ); 
        
        await _googleAccountRepository.AddAsync(googleAccountEntity);

        await _googleAccountRepository.SaveChangesAsync();
    }
}