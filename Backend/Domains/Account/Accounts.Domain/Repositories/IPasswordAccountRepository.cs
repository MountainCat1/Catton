using Accounts.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Accounts.Domain.Repositories;

public interface IPasswordAccountRepository : IRepository<PasswordAccountEntity>
{
    Task<PasswordAccountEntity?> GetAccountByEmailAsync(string email);
}