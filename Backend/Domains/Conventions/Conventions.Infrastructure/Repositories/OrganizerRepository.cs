using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using Conventions.Infrastructure.Contexts;
using MediatR;
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
}