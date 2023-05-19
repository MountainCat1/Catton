using ConventionDomain.Domain.Abstractions;

namespace ConventionDomain.Domain.Entities;

public class Convention : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }
    public bool Active { get; set; }
}