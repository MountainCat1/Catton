using Conventions.Domain.Entities;

namespace ConventionDomain.Application.Dtos.Organizer;

public class OrganizerCreateDto
{
    public Guid ConventionId { get; init; }
    public Guid AccountId { get; init; }
    public OrganizerRole? Role { get; init; }
}