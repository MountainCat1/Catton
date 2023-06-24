using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Infrastructure.Contexts;
using Account.Infrastructure.Generics;
using Catut.Infrastructure.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Infrastructure.Repositories;

public class GoogleAccountRepository : Repository<GoogleAccountEntity, AccountDbContext>, IGoogleAccountRepository
{
    public GoogleAccountRepository(AccountDbContext dbContext, IMediator mediator, ILogger<Repository<GoogleAccountEntity, AccountDbContext>> logger, IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
    
    public async Task<GoogleAccountEntity?> GetAccountByEmailAsync(string email)
    {
        return await GetOneAsync(x => x.Email == email);
    }
}