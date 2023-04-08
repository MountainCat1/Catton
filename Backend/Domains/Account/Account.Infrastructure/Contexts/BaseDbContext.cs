using Account.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Contexts;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AccountEntity>().HasKey(x => x.Id);
        
        // == ACCOUNTS
        
        // email
        modelBuilder.Entity<AccountEntity>().Property(x => x.Email).IsRequired();
        modelBuilder.Entity<AccountEntity>().HasIndex(x => x.Email).IsUnique();
        
        // username
        modelBuilder.Entity<AccountEntity>().Property(x => x.Username).IsRequired();
    }

    public DbSet<AccountEntity> Accounts { get; set; }
    public DbSet<GoogleAccountEntity> GoogleAccounts { get; set; }
}