using System.Linq.Expressions;
using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;

namespace Conventions.Domain.Repositories;

public interface IConventionRepository : IRepository<Convention>
{
    Task<ICollection<Convention>> GetByOrganizatorId(Guid accountId);
    Task<Convention?> GetOneWithOrganizersAsync(string conventionId);
    Task<(Convention? convention, TicketTemplate? ticketTemplate)> GetOneWithTicketTemplateAsync(string conventionId, Guid ticketTemplateId);
    Task<(Convention? convention, Organizer? organizer)> GetOrganizerAsync(string conventionId, Guid organizerId);

    Task<Convention?> GetOneWithAsync(
        string id, 
        params Expression<Func<Convention, object>>[] includeProperties);
    
    Task<Convention?> GET_BIG_BOY(string conventionId);
}