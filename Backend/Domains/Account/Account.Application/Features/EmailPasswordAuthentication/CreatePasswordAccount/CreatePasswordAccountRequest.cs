using Account.Application.Abstractions;

namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequest : IResultRequest
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