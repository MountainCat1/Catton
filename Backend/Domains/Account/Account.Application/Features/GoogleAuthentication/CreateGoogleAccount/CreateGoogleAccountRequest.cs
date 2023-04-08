using Account.Application.Dto;
using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;

public class CreateGoogleAccountRequest : IRequest<Result<GoogleAccountDto>>
{
    public CreateGoogleAccountRequest(string googleAuthToken)
    {
        GoogleAuthToken = googleAuthToken;
    }

    public string GoogleAuthToken { get; set; }
}