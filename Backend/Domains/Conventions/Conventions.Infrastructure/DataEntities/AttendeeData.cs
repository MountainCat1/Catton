using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class AttendeeData
{
    public Guid AccountId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }

    public ICollection<TicketData> Tickets { get; set; }
}

public class AttendeeEntityConfiguration : IEntityTypeConfiguration<AttendeeData>
{
    public void Configure(EntityTypeBuilder<AttendeeData> builder)
    {
        builder.ToTable("Attendees");

        builder.HasKey(a => a.AccountId);

        builder.Property(a => a.CreatedDate)
            .IsRequired();

        builder.Property(a => a.AccountUsername)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.AccountAvatarUri)
            .HasMaxLength(500);

        // Configure relationships, indexes, etc.
    }
}