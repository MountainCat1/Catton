using Account.Domain.Abstractions;
using Account.Domain.DomainEvents;

namespace Account.Domain.Entities;

public abstract class AccountEntity : Entity
{
    protected AccountEntity(string email, string username)
    {
        Username = username;
        Email = email;
        
        AddDomainEvent(new CreateAccountDomainEvent());
    }

    public Guid Id { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
}