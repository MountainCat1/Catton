using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;

namespace Account.Service.Features.EmailPasswordAuthentication.AuthViaPassword;

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