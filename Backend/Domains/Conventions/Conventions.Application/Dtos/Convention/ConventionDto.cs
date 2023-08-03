namespace ConventionDomain.Application.Dtos.Convention;

public record ConventionDto
{
    public required string Id { get; set; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required bool Active { get; init; }
}

public static class ConventionExtensions
{
    public static ConventionDto ToDto(this Conventions.Domain.Entities.Convention convention)
    {
        return new ConventionDto
        {
            Id = convention.Id,
            Name = convention.Name,
            Description = convention.Description,
            Active = convention.Active
        };
    }
}