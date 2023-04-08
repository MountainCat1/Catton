using Account.Application.Dto;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequest : IRequest<GoogleAccountDto>
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}