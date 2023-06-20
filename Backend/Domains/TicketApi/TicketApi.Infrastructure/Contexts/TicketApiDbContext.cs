using Microsoft.EntityFrameworkCore;

namespace TicketApi.Infrastructure.Contexts;

public class TicketApiDbContext : DbContext
{
    public TicketApiDbContext(DbContextOptions<TicketApiDbContext> options) : base(options)
    {
        
    }
}