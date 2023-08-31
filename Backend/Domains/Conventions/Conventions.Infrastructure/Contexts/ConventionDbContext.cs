using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace Conventions.Infrastructure.Contexts;

public class ConventionDomainDbContext : DbContext
{
    public ConventionDomainDbContext(DbContextOptions<ConventionDomainDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.ApplyConfiguration(new ConventionEntityConfiguration());        
        mb.ApplyConfiguration(new OrganizerEntityConfiguration());        
        // mb.ApplyConfiguration(new AttendeeEntityConfiguration());
        //! TODO to change later!!! 
        // mb.ApplyConfiguration(new TicketEntityConfiguration());        
        mb.ApplyConfiguration(new TicketTemplateEntityConfiguration());        
        
        base.OnModelCreating(mb);
    }


    public DbSet<ConventionData> Conventions { get; set; } = null!;
    public DbSet<OrganizerData> Organizers { get; set; } = null!;
    public DbSet<TicketTemplateData> TicketTemplates { get; set; } = null!;
    // public DbSet<Ticket> Tickets { get; set; } = null!;
    // public DbSet<Attendee> Attendees { get; set; } = null!;
}