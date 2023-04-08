using Account.Domain.Abstractions;
using Account.Domain.Entities;

namespace Account.Domain.Repositories;

public interface IGoogleAccountRepository : IRepository<GoogleAccountEntity>
{
    
}