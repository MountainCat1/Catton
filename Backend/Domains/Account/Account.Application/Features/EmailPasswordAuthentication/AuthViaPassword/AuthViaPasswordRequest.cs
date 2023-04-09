using Account.Application.Abstractions;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequest : IResultRequest<AuthViaPasswordResponseDto>
{
    public string Email { get; }
    public string Password { get; }

    public AuthViaPasswordRequest(AuthViaPasswordDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
    }
}