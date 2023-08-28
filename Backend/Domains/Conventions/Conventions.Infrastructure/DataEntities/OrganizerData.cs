using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities
{
    public class OrganizerData
    {
        public Guid AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrganizerRole Role { get; set; }
        public string AccountUsername { get; set; }
        public Uri? AccountAvatarUri { get; set; }
    }

    public class OrganizerEntityConfiguration : IEntityTypeConfiguration<OrganizerData>
    {
        public void Configure(EntityTypeBuilder<OrganizerData> builder)
        {
            builder.ToTable("Organizers");

            builder.HasKey(o => o.AccountId);

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
}