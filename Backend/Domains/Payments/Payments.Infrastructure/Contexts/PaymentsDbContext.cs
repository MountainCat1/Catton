using Payments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Payments.Infrastructure.Contexts
{
    public class PaymentsDbContext : DbContext
    {
        public SomeEntity SomeEntity { get; set; }
    
        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options)
    {
        
    }
    }
}