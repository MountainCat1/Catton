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
        // ORGANIZER
        var organizerEntity = mb.Entity<Organizer>();
        organizerEntity.HasKey(x => new { x.ConventionId, x.AccountId, });
        
        organizerEntity.Property(x => x.AccountId).IsRequired();

        organizerEntity.Property(e => e.Role)
            .HasConversion<string>();

        // TICKET TEMPLATE
        var ticketTemplateEntity = mb.Entity<TicketTemplate>();
        ticketTemplateEntity.HasKey(x => x.Id);
        
        ticketTemplateEntity.Property(x=>x.Price).HasColumnType("money");

        // TICKET
        var ticketEntity = mb.Entity<Ticket>();
        ticketEntity.HasKey(x => x.Id);
        
        
        // ATTENDEE
        var attendeeEntity = mb.Entity<Attendee>();
        attendeeEntity.HasKey(x => new { x.ConventionId, x.AccountId, });
        
        attendeeEntity.Property(x => x.AccountId).IsRequired();


        // CONVENTION
        var conventionEntity = mb.Entity<Convention>();
        conventionEntity.HasKey(e => e.Id);

        conventionEntity.Property(e => e.Id).HasMaxLength(32);
        conventionEntity.Property(x => x.Name).IsRequired();
        conventionEntity.Property(x => x.Description).IsRequired();
        conventionEntity.Property(x => x.CreatedDate).IsRequired();

        conventionEntity.HasMany<Attendee>(x => x.Attendees)
            .WithOne().HasForeignKey(x => x.ConventionId)
            .OnDelete(DeleteBehavior.NoAction);
        conventionEntity.HasMany<Ticket>(x => x.Tickets)
            .WithOne().HasForeignKey(x => x.ConventionId)
            .OnDelete(DeleteBehavior.NoAction);
        conventionEntity.HasMany<TicketTemplate>(x => x.TicketTemplates)
            .WithOne().HasForeignKey(x => x.ConventionId)
            .OnDelete(DeleteBehavior.NoAction);    
        conventionEntity.HasMany<Organizer>(x => x.Organizers)
            .WithOne().HasForeignKey(x => x.ConventionId)
            .OnDelete(DeleteBehavior.NoAction);    

        base.OnModelCreating(mb);
    }


    public DbSet<Convention> Conventions { get; set; } = null!;
    public DbSet<Organizer> Organizers { get; set; } = null!;
    public DbSet<TicketTemplate> TicketTemplates { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Attendee> Attendees { get; set; } = null!;
}