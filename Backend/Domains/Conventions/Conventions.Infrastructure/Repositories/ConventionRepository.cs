using System.Linq.Expressions;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Conventions.Infrastructure.Repositories;

public class ConventionRepository : Repository<Convention, ConventionDomainDbContext>, IConventionRepository
{
    public async Task<ICollection<Convention>> GetByOrganizatorId(Guid accountId)
    {
        var query = DbSet
            .Include(x => x.Organizers)
            .Where(convention => convention.Organizers.Any(organizer => organizer.AccountId == accountId));

        return await query.ToListAsync();
    }

    public async Task<Convention?> GetOneWithAsync(
        Guid id, 
        params Expression<Func<Convention, object>>[] includeProperties)
    {
        var query = DbSet.AsQueryable();
        
        foreach (Expression<Func<Convention, object>> includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        
        return await query.AsSplitQuery().FirstOrDefaultAsync(x => x.Id == id);
    }

    
    public async Task<Convention?> GetOneWithOrganizersAsync(Guid conventionId)
    {
        return await DbSet
            .Include(convention => convention.Organizers)
            .FirstOrDefaultAsync(x => x.Id == conventionId);
    }
    
    public async Task<(Convention? convention, TicketTemplate? ticketTemplate)> GetOneWithTicketTemplateAsync(Guid conventionId, Guid ticketTemplateId)
    {
        var result = await DbContext.Conventions
            .Include(x => x.Organizers)
            .Where(c => c.Id == conventionId)
            .Select(c => new
            {
                Convention = c, 
                TicketTemplate = c.TicketTemplates.FirstOrDefault(tt => tt.Id == ticketTemplateId)
            })
            .FirstOrDefaultAsync();

        return (result?.Convention, result?.TicketTemplate);
    }

    public async Task<(Convention? convention, Organizer? organizer)> GetOrganizerAsync(
        Guid conventionId,
        Guid organizerId)
    {
        var result = await DbContext.Conventions
            .Include(c => c.Organizers)
            .Where(c => c.Id == conventionId)
            .Select(c => new
            {
                Convention = c, 
                Organizer = c.Organizers.FirstOrDefault(o => o.AccountId == organizerId)
            })
            .FirstOrDefaultAsync();
        
        return (result?.Convention, result?.Organizer);
    }

    public ConventionRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<ConventionRepository> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}