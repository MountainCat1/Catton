using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;

namespace Conventions.Domain.Repositories;

public interface IConventionRepository : IRepository<Convention>
{
    Task<ICollection<Convention>> GetByOrganizatorId(Guid accountId);
    Task<Convention?> GetOneWithOrganizersAsync(Guid conventionId);
    Task<(Convention convention, Organizer organizer)> GetOrganizerAsync(Guid conventionId, Guid organizerId);
}