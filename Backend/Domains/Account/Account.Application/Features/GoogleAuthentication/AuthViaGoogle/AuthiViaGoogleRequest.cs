using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IRequest<Result<string>>
{
    public required string GoogleAuthToken { get; set; }
}