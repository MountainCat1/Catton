﻿using Account.Domain.Abstractions;
using Account.Domain.Entities;

namespace Account.Domain.DomainEvents;

public class CreateAccountDomainEvent : DomainEvent<AccountEntity>
{
}