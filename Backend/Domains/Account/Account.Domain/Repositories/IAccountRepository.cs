using Account.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Account.Domain.Repositories;

public interface IAccountRepository : IRepository<AccountEntity>
{
    public Task<AccountEntity?> GetAccountByEmailAsync(string email);
}