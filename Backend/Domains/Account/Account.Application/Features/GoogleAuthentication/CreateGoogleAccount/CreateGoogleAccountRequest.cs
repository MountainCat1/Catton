using Account.Service.Abstractions;

namespace Account.Service.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequest : IResultRequest
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}