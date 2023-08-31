using System.Linq.Expressions;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using Conventions.Infrastructure.Mappings;
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
        string id,
        params Expression<Func<Convention, object>>[] includeProperties)
    {
        var query = DbSet.AsQueryable();

        foreach (Expression<Func<Convention, object>> includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.AsSplitQuery().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Convention?> GetConvention(string conventionId)
    {
        return await DbSet
            .Include(x => x.Organizers)
            .Include(x => x.TicketTemplates)
            .FirstOrDefaultAsync(x => x.Id == conventionId);
    }


    public async Task<Convention?> GetOneWithOrganizersAsync(string conventionId)
    {
        return await DbSet
            .Include(convention => convention.Organizers)
            .FirstOrDefaultAsync(x => x.Id == conventionId);
    }
    

    public ConventionRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<ConventionRepository> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}