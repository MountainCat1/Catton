using Microsoft.EntityFrameworkCore;

namespace TicketTemplateDomain.Infrastructure.Contexts;

public class TicketTemplateDomainDbContext : DbContext
{
    public TicketTemplateDomainDbContext(DbContextOptions<TicketTemplateDomainDbContext> options) : base(options)
    {
        
    }
}