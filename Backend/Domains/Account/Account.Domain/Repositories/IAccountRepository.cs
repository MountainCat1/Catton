using Account.Domain.Abstractions;
using Account.Domain.Entities;

namespace Account.Domain.Repositories;

public interface IAccountRepository : IRepository<AccountEntity>
{
    public Task<AccountEntity?> GetAccountByEmailAsync(string email);
}