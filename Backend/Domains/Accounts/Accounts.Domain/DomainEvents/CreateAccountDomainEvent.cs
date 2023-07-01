using Accounts.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Accounts.Domain.DomainEvents;

public class CreateAccountDomainEvent : DomainEvent<AccountEntity>
{
}