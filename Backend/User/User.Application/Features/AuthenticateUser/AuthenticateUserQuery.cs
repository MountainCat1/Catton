using MediatR;

namespace User.Application.Features.AuthenticateUser;

public class AuthenticateUserQuery : IRequest<string>
{
    public string Username { get; set; }
    public string Password { get; set; }
    
}