using Account.Application.Abstractions;
using Account.Application.Extensions.DtoMapping;
using Account.Contracts;
using Account.Domain.DomainEvents;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using LanguageExt;
using LanguageExt.Common;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

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

        var googleAccount = new GoogleAccountEntity()
        {
            Email = googleTokenPayload.Email,
            Username = $"{googleTokenPayload.Name} {googleTokenPayload.FamilyName}",
        };

        var createdEntity = await _googleAccountRepository.CreateAsync(googleAccount);
        
        createdEntity.AddDomainEvent(new CreateAccountDomainEvent());
        
        var dbException = await _googleAccountRepository.SaveChangesAsync();

        if (dbException is not null)
            return new Result<Unit>(dbException);
        
        return new Result<Unit>();
    }
}