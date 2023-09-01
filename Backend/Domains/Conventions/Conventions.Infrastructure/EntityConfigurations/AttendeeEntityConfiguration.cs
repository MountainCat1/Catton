using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.EntityConfigurations;

public class AttendeeEntityConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.ToTable("Attendees");

        builder.HasKey(t => t.Id);

        builder.HasIndex(x => x.AccountId);

        builder.Property(t => t.AccountUsername)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.AccountAvatarUri)
            .HasMaxLength(500);

        builder.Property(t => t.CreatedDate)
            .IsRequired();
        
        // Configure relationships, indexes, etc.
    }
}