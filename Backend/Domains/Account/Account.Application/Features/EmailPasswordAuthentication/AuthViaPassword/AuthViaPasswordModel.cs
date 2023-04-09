namespace Account.Application.Features.EmailPasswordAuthentication;

public class AuthViaPasswordModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}