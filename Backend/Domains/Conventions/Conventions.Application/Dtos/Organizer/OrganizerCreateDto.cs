using Conventions.Domain.Entities;

namespace Conventions.Application.Dtos.Organizer;

public class OrganizerCreateDto
{
    public Guid ConvnetionId { get; init; }
    public Guid AccountId { get; init; }
    public OrganizerRole? Role { get; init; }
}