using Account.Application.Dto;
using Account.Application.Extensions.DtoMapping;
using Account.Domain.Repositories;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequestHandler : IRequestHandler<CreateGoogleAccountRequest, GoogleAccountDto>
{
    private readonly IGoogleAccountRepository _googleAccountRepository;
    private readonly IGoogleAuthProviderService _googleService;
    
    public CreateGoogleAccountRequestHandler(IGoogleAccountRepository googleAccountRepository, IGoogleAuthProviderService googleService)
    {
        _googleAccountRepository = googleAccountRepository;
        _googleService = googleService;
    }

    public async Task<GoogleAccountDto> Handle(CreateGoogleAccountRequest request, CancellationToken cancellationToken)
    {
        var googleTokenPayload = await _googleService.ValidateGoogleJwtAsync(request.GoogleAuthToken);

        var googleAccount = new GoogleAccountEntity()
        {
            Email = googleTokenPayload.Email,
        };

        // TODO add some type of validation so you cannot create two users with the same email
        await _googleAccountRepository.SaveChangesAsync();

        return googleAccount.ToDto();
    }
}