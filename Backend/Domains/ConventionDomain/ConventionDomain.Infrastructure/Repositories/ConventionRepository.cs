using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Contexts;
using ConventionDomain.Infrastructure.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Infrastructure.Repositories;

public class ConventionRepository : Repository<Convention, ConventionDomainDbContext>, IConventionRepository
{
    public ConventionRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<Convention, ConventionDomainDbContext>> logger) 
        : base(dbContext, mediator, logger)
    {
    }


    public async Task<ICollection<Convention>> GetByOrganizatorId(Guid accountId)
    {
        var query = DbSet
            .Include(x => x.Organizers)
            .Where(convention => convention.Organizers.Any(organizer => organizer.AccountId == accountId));

        return await query.ToListAsync();
    }
}