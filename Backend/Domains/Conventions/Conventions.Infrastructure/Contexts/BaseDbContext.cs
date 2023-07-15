using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conventions.Infrastructure.Contexts;

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
        var organizerEntity = mb.Entity<Organizer>();
        organizerEntity.HasKey(x => new { x.ConventionId, x.AccountId, });
        
        organizerEntity.Property(x => x.AccountId).IsRequired();

        organizerEntity
            .Property(e => e.Role)
            .HasConversion<string>();
        
        // TICKET TEMPLATE
        var ticketTemplateEntity = mb.Entity<TicketTemplate>();
        ticketTemplateEntity.HasKey(x => x.Id);
        
        ticketTemplateEntity.Property(x=>x.Price).HasColumnType("money");
        
        base.OnModelCreating(mb);
    }


    public DbSet<Convention> Conventions { get; set; } = null!;
    public DbSet<Organizer> Organizers { get; set; } = null!;
    public DbSet<TicketTemplate> TicketTemplates { get; set; } = null!;
}