﻿using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;
using Accounts.Infrastructure.Contexts;
using Accounts.Infrastructure.Generics;
using Catut.Infrastructure.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Accounts.Infrastructure.Repositories;

public class PasswordAccountRepository : Repository<PasswordAccountEntity, AccountDbContext>, IPasswordAccountRepository
{
    public PasswordAccountRepository(AccountDbContext dbContext, IMediator mediator, ILogger<Repository<PasswordAccountEntity, AccountDbContext>> logger, IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
    
    public async Task<PasswordAccountEntity?> GetAccountByEmailAsync(string email)
    {
        return await GetOneAsync(x => x.Email == email);
    }
}