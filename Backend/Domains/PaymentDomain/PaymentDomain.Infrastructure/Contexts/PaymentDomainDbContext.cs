using Microsoft.EntityFrameworkCore;
using PaymentDomain.Domain.Entities;

namespace PaymentDomain.Infrastructure.Contexts;

public class PaymentDomainDbContext : DbContext
{
    public DbSet<ConventionTicket> ConventionTickets { get; set; }

    public PaymentDomainDbContext(DbContextOptions<PaymentDomainDbContext> options) : base(options)
    {
        
    }
}