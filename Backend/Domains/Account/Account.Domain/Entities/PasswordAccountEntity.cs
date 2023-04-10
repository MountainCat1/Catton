using Account.Domain.DomainEvents;

namespace Account.Domain.Entities;

public class PasswordAccountEntity : AccountEntity
{
    // public PasswordAccountEntity(string email, string passwordHash, string username)
    // {
    //     PasswordHash = passwordHash;
    //     Email = email;
    //     Username = username;
    //     
    //     AddDomainEvent(new CreateAccountDomainEvent());
    // }

    public string PasswordHash { get; set; }

    public PasswordAccountEntity(string email, string username, string passwordHash) : base(email, username)
    {
        PasswordHash = passwordHash;
    }
}