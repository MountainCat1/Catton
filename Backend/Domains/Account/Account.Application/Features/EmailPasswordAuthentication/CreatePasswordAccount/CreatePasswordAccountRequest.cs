using Account.Application.Abstractions;
using Account.Contracts;
using MediatR;

namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequest : IResultRequest<Unit>
{
    public CreatePasswordAccountRequest(CreatePasswordAccountDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
        Username = dto.Username;
    }

    public string Email { get; }
    public string Password { get; }
    public string Username { get; }
}