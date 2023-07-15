using System.Linq.Expressions;
using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;

namespace Conventions.Domain.Repositories;

public interface IConventionRepository : IRepository<Convention>
{
    Task<ICollection<Convention>> GetByOrganizatorId(Guid accountId);
    Task<Convention?> GetOneWithOrganizersAsync(Guid conventionId);
    Task<(Convention? convention, TicketTemplate? ticketTemplate)> GetOneWithTicketTemplateAsync(Guid conventionId, Guid ticketTemplateId);
    Task<(Convention? convention, Organizer? organizer)> GetOrganizerAsync(Guid conventionId, Guid organizerId);

    Task<Convention?> GetOneWithAsync(
        Guid id, 
        params Expression<Func<Convention, object>>[] includeProperties);
}