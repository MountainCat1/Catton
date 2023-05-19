using ConventionDomain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConventionDomain.Infrastructure.Contexts;

public class ConventionDomainDbContext : DbContext
{
    public ConventionDomainDbContext(DbContextOptions<ConventionDomainDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Convention>().HasKey(e => e.Id);

        modelBuilder.Entity<Convention>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Convention>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<Convention>().Property(x => x.CreatedDate).IsRequired();
        
        modelBuilder.Entity<Convention>()
            .Property(e => e.CreatedDate)
            .HasComputedColumnSql("GETDATE()");
        
        
        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Convention> Conventions { get; set; } = null!;
}