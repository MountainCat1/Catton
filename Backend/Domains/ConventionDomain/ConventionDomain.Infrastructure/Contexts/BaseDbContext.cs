using ConventionDomain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConventionDomain.Infrastructure.Contexts;

public class ConventionDomainDbContext : DbContext
{
    public ConventionDomainDbContext(DbContextOptions<ConventionDomainDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        
        // CONVENTION
        var conventionEntity = mb.Entity<Convention>();
        conventionEntity.HasKey(e => e.Id);

        conventionEntity.Property(x => x.Name).IsRequired();
        conventionEntity.Property(x => x.Description).IsRequired();
        conventionEntity.Property(x => x.CreatedDate).IsRequired();


        // ORGANIZER
        var organizerEntity = mb.Entity<ConventionOrganizer>();

        organizerEntity.HasKey(x => x.Id);

        organizerEntity.Property(x => x.AccountId).IsRequired();

        base.OnModelCreating(mb);
    }


    public DbSet<Convention> Conventions { get; set; } = null!;
    public DbSet<ConventionOrganizer> Organizers { get; set; } = null!;
}