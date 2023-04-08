using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Generics;

namespace Account.Infrastructure.Repositories;

public class GoogleAccountRepository : Repository<GoogleAccountEntity, AccountDbContext>, IGoogleAccountRepository
{
    public GoogleAccountRepository(AccountDbContext dbContext) : base(dbContext)
    {
    }
}