﻿using Catut.Domain.Abstractions;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }


    public DateTime CreatedDate { get; set; }    
    
    public Guid AtendeeId { get; set; }
    public Guid PaymentId { get; set; }
    
    public TicketTemplate TicketTemplate { get; set; } = null!;

    public Guid AttendeeId { get; set; }
    public Guid TicketTemplateId { get; set; }

    private Ticket()
    {
    }

    internal static Ticket Create(TicketTemplate ticketTemplate, Attendee attendee)
    {
        var entity = new Ticket()
        {
            TicketTemplate = ticketTemplate,
            TicketTemplateId = ticketTemplate.Id,
            AtendeeId = attendee.AccountId,
            
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