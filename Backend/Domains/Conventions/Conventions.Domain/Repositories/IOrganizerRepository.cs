using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;

namespace Conventions.Domain.Repositories;

public interface IOrganizerRepository : IRepository<Organizer>
{
    Task<ICollection<Organizer>> GetAllOrganizersForConvention(Guid conventionId);
    Task<Organizer?> GetOneWithConventionAsync(Guid conventionId, Guid organizerId);
}