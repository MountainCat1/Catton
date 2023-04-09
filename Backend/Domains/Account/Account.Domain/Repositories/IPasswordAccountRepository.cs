using Account.Domain.Abstractions;
using Account.Domain.Entities;

namespace Account.Domain.Repositories;

public interface IPasswordAccountRepository : IRepository<PasswordAccountEntity>
{
    
}