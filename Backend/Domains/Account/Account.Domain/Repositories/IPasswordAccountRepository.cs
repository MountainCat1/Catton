using Account.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Account.Domain.Repositories;

public interface IPasswordAccountRepository : IRepository<PasswordAccountEntity>
{
    Task<PasswordAccountEntity?> GetAccountByEmailAsync(string email);
}