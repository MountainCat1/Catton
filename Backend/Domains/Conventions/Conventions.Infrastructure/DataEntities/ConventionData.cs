using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class ConventionData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }

    public ICollection<OrganizerData> Organizers { get; set; }
    public ICollection<TicketTemplateData> TicketTemplates { get; set; }
    public ICollection<AttendeeData> Attendees { get; set; }
}

public class ConventionEntityConfiguration : IEntityTypeConfiguration<ConventionData>
{
    public void Configure(EntityTypeBuilder<ConventionData> builder)
    {
        builder.ToTable("Conventions");

        builder.HasKey(c => c.Id);
            
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.CreatedDate)
            .IsRequired();

        builder.Property(c => c.Active)
            .IsRequired();
                
        // Configure relationships, indexes, etc.
    }
}