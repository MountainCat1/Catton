using Account.Application.Abstractions;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IResultRequest<string>
{
    public required string GoogleAuthToken { get; set; }
}