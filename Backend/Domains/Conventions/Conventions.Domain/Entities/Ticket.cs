using Catut.Domain.Abstractions;
using FluentValidation;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }


    public DateTime CreatedDate { get; set; }    
    
    public Guid AtendeeId { get; set; }
    public Guid PaymentId { get; set; }
    
    public Guid TicketTemplateId { get; set; }
    public Guid ConventionId { get; set; }

    public virtual TicketTemplate TicketTemplate { get; set; } = null!;
    public virtual Convention Convention { get; set; } = null!;

    private Ticket()
    {
    }

    public static Ticket Create()
    {
        var entity = new Ticket()
        {
            CreatedDate = DateTime.Now
        };

        entity.ValidateAndThrow();

        return entity;
    }
    
    public void ValidateAndThrow()
    {
        new TicketValidator().ValidateAndThrow(this);
    }
}