namespace ConventionDomain.Application.Dtos;

public record CreateConventionDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}