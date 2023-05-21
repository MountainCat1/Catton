namespace ConventionDomain.Application.Dtos;

public class CreateConventionDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
}