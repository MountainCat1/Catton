using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.EntityConfigurations;

public class TicketTemplateEntityConfiguration : IEntityTypeConfiguration<TicketTemplate>
{
    public void Configure(EntityTypeBuilder<TicketTemplate> builder)
    {
        builder.ToTable("TicketTemplates");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.Price)
            .IsRequired();

        builder.Property(t => t.Avaliable)
            .IsRequired();

        builder.Property(t => t.CreateDate)
            .IsRequired();

        builder.Property(t => t.LastUpdateDate)
            .IsRequired();

        // Configure relationships, indexes, etc.
    }
}