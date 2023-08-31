using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class OrganizerData
{
    public Guid AccountId { private set; get; }
    
    public DateTime CreatedDate { get; set; }
    
    public virtual OrganizerRole Role { get; set; }
    
    // Data from account entity
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }

    public string ConventionId { get; set; }
}

public class OrganizerEntityConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.ToTable("Organizers");

        builder.HasKey(o => new {o.Id});

        builder.Property(o => o.CreatedDate)
            .IsRequired();

        builder.Property(o => o.Role)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(o => o.AccountUsername)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(o => o.AccountAvatarUri)
            .HasMaxLength(500);

        // Configure relationships, indexes, etc.
    }
}