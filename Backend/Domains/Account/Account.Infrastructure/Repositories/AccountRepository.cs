using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Infrastructure.Repositories;

public class AccountRepository : Repository<AccountEntity, AccountDbContext>, IAccountRepository
{
    public AccountRepository(AccountDbContext dbContext, IMediator mediator, ILogger<Repository<AccountEntity, AccountDbContext>> logger) : base(dbContext, mediator, logger)
    {
    }

    public async Task<AccountEntity?> GetAccountByEmailAsync(string email)
    {
        return await GetOneAsync(x => x.Email == email);
    }
}