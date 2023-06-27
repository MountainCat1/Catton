namespace ConventionDomain.Application.Dtos.Convention;

public class ConventionUpdateDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public bool? Active { get; init; }
}