using Accounts.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Accounts.Domain.Repositories;

public interface IAccountRepository : IRepository<AccountEntity>
{
    public Task<AccountEntity?> GetAccountByEmailAsync(string email);
}