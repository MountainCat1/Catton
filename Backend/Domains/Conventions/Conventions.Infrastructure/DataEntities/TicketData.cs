using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.CreatedDate)
            .IsRequired();

        builder.Property(t => t.AttendeeId)
            .IsRequired();

        builder.Property(t => t.PaymentId)
            .IsRequired();

        builder.Property(t => t.TicketTemplateId)
            .IsRequired();

        // Configure relationships, indexes, etc.
    }
}