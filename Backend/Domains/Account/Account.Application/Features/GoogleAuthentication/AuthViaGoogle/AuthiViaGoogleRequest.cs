using MediatR;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IRequest<string>
{
    public string GoogleAuthToken { get; set; }
}