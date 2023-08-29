
using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class AttendeeEntityConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.ToTable("Attendees");

        builder.HasKey(a => new {a.AccountId, a.ConventionId});

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