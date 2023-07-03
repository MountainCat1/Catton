﻿using Catut.Infrastructure.Abstractions;
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

    public async Task<Convention?> GetOneWithOrganizersAsync(Guid conventionId)
    {
        return await DbSet
            .Include(convention => convention.Organizers)
            .FirstOrDefaultAsync(x => x.Id == conventionId);
    }

    public async Task<(Convention? convention, Organizer? organizer)> GetOrganizerAsync(
        Guid conventionId,
        Guid organizerId)
    {
        var convention = await DbContext.Conventions
            .Include(c => c.Organizers)
            .FirstOrDefaultAsync(c => c.Id == conventionId);

        if (convention is null)
            return (null, null);

        var organizer = convention.Organizers.FirstOrDefault(o => o.AccountId == organizerId);

        return (convention, organizer);
    }

    public ConventionRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<Convention, ConventionDomainDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}