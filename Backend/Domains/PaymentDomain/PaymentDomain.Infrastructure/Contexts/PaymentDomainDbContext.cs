using Microsoft.EntityFrameworkCore;

namespace PaymentDomain.Infrastructure.Contexts;

public class PaymentDomainDbContext : DbContext
{
    public PaymentDomainDbContext(DbContextOptions<PaymentDomainDbContext> options) : base(options)
    {
        
    }
}