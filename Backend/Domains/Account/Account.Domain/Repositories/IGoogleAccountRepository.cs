using Account.Domain.Entities;
using Catut.Domain.Abstractions;

namespace Account.Domain.Repositories;

public interface IGoogleAccountRepository : IRepository<GoogleAccountEntity>
{
    Task<GoogleAccountEntity?> GetAccountByEmailAsync(string email);
}