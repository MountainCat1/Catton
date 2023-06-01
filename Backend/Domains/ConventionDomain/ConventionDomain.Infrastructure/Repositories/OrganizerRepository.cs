using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Contexts;
using ConventionDomain.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ConventionDomain.Infrastructure.Repositories;

public class OrganizerRepository : Repository<Organizer, ConventionDomainDbContext>, IOrganizerRepository
{
    public OrganizerRepository(
        ConventionDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<Organizer, ConventionDomainDbContext>> logger) : base(dbContext,
        mediator,
        logger)
    {
    }
}