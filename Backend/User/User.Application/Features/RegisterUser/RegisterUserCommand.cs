using MediatR;

namespace User.Application.Features.RegisterUser;

public class RegisterUserCommand : IRequest
{
    public RegisterUserCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; set; }
    public string Password { get; set; }
}