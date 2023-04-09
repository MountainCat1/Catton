using Account.Contracts.Abstractions;
using Account.Domain.Entities;

namespace Account.Contracts;

public class AccountDto : IDto<AccountEntity>
{
    public string Email { get; set; }
    public string Username { get; set; }
}