using Account.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Account.Domain.DomainEvents;

public class CreateAccountDomainEvent : DomainEvent<AccountEntity>
{
}