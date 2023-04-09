using Account.Application.Abstractions;
using Account.Contracts;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequest : IResultRequest<GoogleAccountDto>
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}