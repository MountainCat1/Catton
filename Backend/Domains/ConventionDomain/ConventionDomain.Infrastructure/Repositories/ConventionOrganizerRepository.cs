using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Contexts;
using ConventionDomain.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Infrastructure.Repositories;

public class ConventionOrganizerRepository : Repository<ConventionOrganizer, ConventionDomainDbContext>, IConventionOrganizerRepository
{
    public ConventionOrganizerRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<ConventionOrganizer, ConventionDomainDbContext>> logger) : base(dbContext,
        mediator,
        logger)
    {
    }
}