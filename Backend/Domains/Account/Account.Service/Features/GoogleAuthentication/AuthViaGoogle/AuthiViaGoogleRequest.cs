using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;

namespace Account.Service.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IResultRequest<AuthTokenResponseDto>
{
    public required string GoogleAuthToken { get; set; }
}