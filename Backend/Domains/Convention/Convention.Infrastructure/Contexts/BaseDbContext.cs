using Microsoft.EntityFrameworkCore;

namespace Convention.Infrastructure.Contexts;

public class ConventionDbContext : DbContext
{
    public ConventionDbContext(DbContextOptions<ConventionDbContext> options) : base(options)
    {
        
    }
}