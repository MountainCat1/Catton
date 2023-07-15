using Payment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Payment.Infrastructure.Contexts;

public class PaymentDbContext : DbContext
{
    public SomeEntity SomeEntity { get; set; }
    
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {
        
    }
}