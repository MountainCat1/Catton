using ConventionDomain.Domain.Entities;

namespace ConventionDomain.Application.Dtos.Organizer;

public record OrganizerResponse
{
    public Guid Id { get; init; }
    public Guid AccountId { get; init; }
    public Guid ConventionId { get; init; }
    public DateTime CreatedDate { get; init; }
    public OrganizerRole Role { get; init; }
}

public static class ConventionOrganizerExtensions
{
    public static OrganizerResponse ToDto(this Domain.Entities.Organizer organizer)
    {
        return new OrganizerResponse
        {
            Id = organizer.Id,
            AccountId = organizer.AccountId,
            ConventionId = organizer.ConventionId,
            CreatedDate = organizer.CreatedDate,
            Role = organizer.Role
        };
    }
}