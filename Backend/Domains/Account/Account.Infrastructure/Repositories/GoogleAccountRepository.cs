using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Generics;
using MediatR;

namespace Account.Infrastructure.Repositories;

public class GoogleAccountRepository : Repository<GoogleAccountEntity, AccountDbContext>, IGoogleAccountRepository
{
    public GoogleAccountRepository(AccountDbContext dbContext, IMediator mediator) : base(dbContext, mediator)
    {
    }
}