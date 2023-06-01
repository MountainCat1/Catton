namespace ConventionDomain.Application.Dtos;

public record ConventionCreateDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}