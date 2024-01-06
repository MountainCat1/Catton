using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payments.Domain.Entities;

namespace Payments.Infrastructure.EntityConfigurations;

public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(x => x.Id);

        builder.Property(o => o.PaymentStatus)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Currency)
            .HasMaxLength(64)
            .IsRequired();

        builder.Property(x => x.Amount).IsRequired().HasPrecision(10, 2);

        builder.OwnsOne(x => x.CheckoutSession, sa =>
        {
            sa.Property(p => p.Id).IsRequired();
            sa.Property(p => p.ExpiresAt).IsRequired();
            sa.Property(p => p.Url).IsRequired();
        });
    }
}