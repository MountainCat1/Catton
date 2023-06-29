using Accounts.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Accounts.Domain.Repositories;

public interface IGoogleAccountRepository : IRepository<GoogleAccountEntity>
{
    Task<GoogleAccountEntity?> GetAccountByEmailAsync(string email);
}