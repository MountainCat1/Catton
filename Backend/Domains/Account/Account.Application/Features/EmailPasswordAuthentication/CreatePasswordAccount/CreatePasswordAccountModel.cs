namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}