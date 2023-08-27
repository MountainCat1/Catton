using Catut.Domain.Abstractions;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }


    public DateTime CreatedDate { get; set; }    
    
    public Guid AtendeeId { get; set; }
    public Guid PaymentId { get; set; }
    
    public Guid TicketTemplateId { get; set; }
    public string ConventionId { get; set; }

    public virtual TicketTemplate TicketTemplate { get; set; } = null!;
    public virtual Convention Convention { get; set; } = null!;

    private Ticket()
    {
    }

    public static Ticket Create(Guid atendeeId, Guid ticketTemplateId, string conventionId)
    {
        var entity = new Ticket()
        {
            AtendeeId = atendeeId,
            TicketTemplateId = ticketTemplateId,
            ConventionId = conventionId,
            
            CreatedDate = DateTime.Now,
        };
        
        //! TODO
        // Add payment creation
        // entity.PaymentId = Payment.Create().Id; 
        

        entity.ValidateAndThrow();

        return entity;
    }
    
    public void ValidateAndThrow()
    {
        new TicketValidator().ValidateAndThrow(this);
    }
}