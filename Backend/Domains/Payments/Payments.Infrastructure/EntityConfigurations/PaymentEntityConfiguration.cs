using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            .HasConversion(x => x.ToString(), x => Enum.Parse<PaymentStatus>(x));
    }
}
