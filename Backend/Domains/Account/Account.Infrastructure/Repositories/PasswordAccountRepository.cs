using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Infrastructure.Repositories;

public class PasswordAccountRepository : Repository<PasswordAccountEntity, AccountDbContext>, IPasswordAccountRepository
{
    public PasswordAccountRepository(AccountDbContext dbContext, IMediator mediator, ILogger<Repository<PasswordAccountEntity, AccountDbContext>> logger) : base(dbContext, mediator, logger)
    {
    }
}