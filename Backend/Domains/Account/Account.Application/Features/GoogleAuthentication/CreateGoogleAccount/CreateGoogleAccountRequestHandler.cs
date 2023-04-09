using Account.Application.Dto;
using Account.Application.Extensions.DtoMapping;
using Account.Domain.DomainEvents;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequestHandler : IRequestHandler<CreateGoogleAccountRequest, Result<GoogleAccountDto>>
{
    private readonly IGoogleAccountRepository _googleAccountRepository;
    private readonly IGoogleAuthProviderService _googleService;
    
    public CreateGoogleAccountRequestHandler(IGoogleAccountRepository googleAccountRepository, IGoogleAuthProviderService googleService)
    {
        _googleAccountRepository = googleAccountRepository;
        _googleService = googleService;
    }

    public async Task<Result<GoogleAccountDto>> Handle(CreateGoogleAccountRequest request, CancellationToken cancellationToken)
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
            return new Result<GoogleAccountDto>(dbException);
        
        return googleAccount.ToDto();
    }
}