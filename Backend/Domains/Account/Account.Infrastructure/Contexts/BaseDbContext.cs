using Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Contexts;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
        
    }

    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<GoogleAccountEntity> GoogleAccounts { get; set; }
}