using System.Runtime.CompilerServices;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Catut;
using Google.Apis.Auth;
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
        
        var googleAccountEntity = new GoogleAccountEntity(
            email: googleTokenPayload.Email,
            username: googleTokenPayload.Name
        ); 
        
        await _googleAccountRepository.AddAsync(googleAccountEntity);

        var dbException = await _googleAccountRepository.SaveChangesAsync();

        if (dbException is not null)
            throw dbException;
    }
}