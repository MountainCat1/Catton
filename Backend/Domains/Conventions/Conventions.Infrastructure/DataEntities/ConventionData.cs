using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class ConventionEntityConfiguration : IEntityTypeConfiguration<Convention>
{
    public void Configure(EntityTypeBuilder<Convention> builder)
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