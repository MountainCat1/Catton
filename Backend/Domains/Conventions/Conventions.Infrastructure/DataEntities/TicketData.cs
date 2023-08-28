using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.DataEntities;

public class TicketData
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid AttendeeId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid TicketTemplateId { get; set; }
}

public class TicketEntityConfiguration : IEntityTypeConfiguration<TicketData>
{
    public void Configure(EntityTypeBuilder<TicketData> builder)
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