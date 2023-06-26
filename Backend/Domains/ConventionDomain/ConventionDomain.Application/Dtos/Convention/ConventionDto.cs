namespace ConventionDomain.Application.Dtos.Convention;

public record ConventionResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required bool Active { get; init; }
}

public static class ConventionExtensions
{
    public static ConventionResponse ToDto(this Domain.Entities.Convention convention)
    {
        return new ConventionResponse
        {
            Id = convention.Id,
            Name = convention.Name,
            Description = convention.Description,
            Active = convention.Active
        };
    }
}