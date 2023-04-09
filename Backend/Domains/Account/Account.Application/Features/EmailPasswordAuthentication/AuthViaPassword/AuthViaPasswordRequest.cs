using Account.Application.Abstractions;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequest : IResultRequest<string>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}