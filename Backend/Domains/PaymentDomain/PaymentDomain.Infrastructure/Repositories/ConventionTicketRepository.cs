using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Generics;
using MediatR;
using Microsoft.Extensions.Logging;
using PaymentDomain.Domain.Entities;
using PaymentDomain.Domain.Repositories;
using PaymentDomain.Infrastructure.Contexts;

namespace PaymentDomain.Infrastructure.Repositories;

public class ConventionTicketRepository : Repository<ConventionTicket, PaymentDomainDbContext>, IConventionTicketRepository
{
    public ConventionTicketRepository(
        PaymentDomainDbContext dbContext,
        IMediator mediator,
        ILogger<Repository<ConventionTicket, PaymentDomainDbContext>> logger,
        IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}