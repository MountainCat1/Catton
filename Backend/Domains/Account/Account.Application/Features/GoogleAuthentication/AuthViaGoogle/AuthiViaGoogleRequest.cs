using Account.Application.Abstractions;
using Account.Application.Dtos.Responses;

namespace Account.Application.Features.GoogleAuthentication.AuthViaGoogle;

public class AuthiViaGoogleRequest : IResultRequest<AuthTokenResponseDto>
{
    public required string GoogleAuthToken { get; set; }
}