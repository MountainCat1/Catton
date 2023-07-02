using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Conventions.Infrastructure.Repositories;

public class OrganizerRepository : Repository<Organizer, ConventionDomainDbContext>, IOrganizerRepository
{
    public OrganizerRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<Organizer, ConventionDomainDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }

    public async Task<ICollection<Organizer>> GetAllOrganizersForConvention(Guid conventionId)
    {
        return await DbSet
            .Include(x => x.Convention)
            .Where(x => x.ConventionId == conventionId)
            .ToListAsync();
    }
    
    
    public async Task<Organizer?> GetOneWithConventionAsync(Guid conventionId, Guid organizerId)
    {
        return await DbSet
            .Include(organizer => organizer.Convention)
            .Where(organizer => organizer.Convention.Id == conventionId)
            .Where(organizer => organizer.AccountId == organizerId)
            .FirstOrDefaultAsync();
    }
}