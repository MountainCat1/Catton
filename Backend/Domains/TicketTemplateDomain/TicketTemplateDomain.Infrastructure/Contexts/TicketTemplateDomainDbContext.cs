using Microsoft.EntityFrameworkCore;
using TicketTemplateDomain.Domain.Entities;

namespace TicketTemplateDomain.Infrastructure.Contexts;

public class TicketTemplateDomainDbContext : DbContext
{
    public DbSet<TicketTemplate> TicketTemplates { get; set; }
    public TicketTemplateDomainDbContext(DbContextOptions<TicketTemplateDomainDbContext> options) : base(options)
    {
        
    }
}