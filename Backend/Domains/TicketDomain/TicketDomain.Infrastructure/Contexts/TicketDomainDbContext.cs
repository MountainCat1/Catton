using Microsoft.EntityFrameworkCore;

namespace TicketDomain.Infrastructure.Contexts;

public class TicketDomainDbContext : DbContext
{
    public TicketDomainDbContext(DbContextOptions<TicketDomainDbContext> options) : base(options)
    {
        
    }
}