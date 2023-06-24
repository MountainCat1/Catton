using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Infrastructure.Repositories;

public class OrganizerRepository : Repository<Organizer, ConventionDomainDbContext>, IOrganizerRepository
{
    public OrganizerRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<Organizer, ConventionDomainDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}