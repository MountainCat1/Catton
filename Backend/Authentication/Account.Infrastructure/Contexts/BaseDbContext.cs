using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Contexts;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
        
    }
}