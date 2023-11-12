using Catut.Domain.Abstractions;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }

    public TicketTemplate TicketTemplate { get; set; }

    public DateTime CreatedDate { get; set; }

    private Ticket()
    {
    }

    internal static Ticket CreateInstance(TicketTemplate ticketTemplate)
    {
        var instance = new Ticket()
        {
            Id = Guid.Empty, // sets to empty so that EF won't think its an existing entity
            TicketTemplate = ticketTemplate,
            CreatedDate = DateTime.Now,
        };

        return instance;
    }
}