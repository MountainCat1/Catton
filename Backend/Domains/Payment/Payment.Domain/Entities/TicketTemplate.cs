using Catut.Domain.Abstractions;

namespace Payment.Domain.Entities;

public class TicketTemplate : Entity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }

    public Guid ConventionId { get; set; }

    private TicketTemplate(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static TicketTemplate Create(string name, string description)
    {
        return new TicketTemplate(name, description);
    }
}