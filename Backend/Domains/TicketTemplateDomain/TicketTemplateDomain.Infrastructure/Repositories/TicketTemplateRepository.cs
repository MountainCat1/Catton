using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketTemplateDomain.Domain.Entities;
using TicketTemplateDomain.Domain.Repositories;
using TicketTemplateDomain.Infrastructure.Abstractions;
using TicketTemplateDomain.Infrastructure.Contexts;
using TicketTemplateDomain.Infrastructure.Generics;

namespace TicketTemplateDomain.Infrastructure.Repositories;

public class TicketTemplateRepository : Repository<TicketTemplate, TicketTemplateDomainDbContext>, ITicketTemplateRepository
{
    public DbSet<TicketTemplate> TicketTemplates { get; set; }


    public TicketTemplateRepository(TicketTemplateDomainDbContext dbContext, IMediator mediator, ILogger<Repository<TicketTemplate, TicketTemplateDomainDbContext>> logger, IDatabaseErrorMapper databaseErrorMapper) : base(dbContext, mediator, logger, databaseErrorMapper)
    {
    }
}