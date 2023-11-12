using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.EntityConfigurations;

public class TicketEntityConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(o => new {o.Id});

        builder.Property(o => o.Id)
            .ValueGeneratedNever();
        
        builder.Property(o => o.CreatedDate)
            .IsRequired();
    }
}