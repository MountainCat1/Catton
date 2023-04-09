using Account.Application.Abstractions;
using Account.Application.Dtos.Responses;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequest : IResultRequest<AuthTokenResponseDto>
{
    public string Email { get; }
    public string Password { get; }

    public AuthViaPasswordRequest(AuthViaPasswordDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
    }
}