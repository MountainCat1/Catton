using Catut.Domain.Abstractions;
using Conventions.Domain.Events;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public record ConventionUpdate
{
    public string? Name { get; init; }
    public string? Description { get; init; }  
    public bool? Active { get; init; }  
}

public class Convention : Entity
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public DateTime CreatedDate { private set; get; }
    public bool Active { get; private set; }

    public ICollection<Organizer> Organizers { get; private set; }
    public ICollection<TicketTemplate> TicketTemplates { get; private set; }
    public ICollection<Attendee> Attendees { get; private set; }


    private Convention()
    {
    }

    public static Convention CreateInstance(string id, string name, string description, Guid creatorId)
    {
        var entity = new Convention
        {
            Id = id,
            Name = name,
            Description = description,
            CreatedDate = DateTime.Now
        };

        entity.Organizers = new List<Organizer>();
        entity.TicketTemplates = new List<TicketTemplate>();

        entity.ValidateAndThrow();
        
        entity.AddDomainEvent(new ConventionCreatedDomainEvent()
        {
            AccountId = creatorId
        });

        return entity;
    }

    public void Update(ConventionUpdate update)
    {
        Name = update.Name ?? Name;
        Description = update.Description ?? Description;
        Active = update.Active ?? Active;
        
        ValidateAndThrow();
    }
    
    public void ValidateAndThrow()
    {
        new ConventionValidator().ValidateAndThrow(this);
    }

    public void AddOrganizer(Organizer organizer)
    {
        Organizers.Add(organizer);
    }

    public Organizer? RemoveOrganizer(Guid organizerId)
    {
        var organizerToRemove = Organizers.FirstOrDefault(x => x.AccountId == organizerId);

        if (organizerToRemove is null)
            return null;

        Organizers.Remove(organizerToRemove);

        return organizerToRemove;
    }

    public void AddTicketTemplate(TicketTemplate ticketTemplate)
    {
        TicketTemplates.Add(ticketTemplate);
    }

    public TicketTemplate RemoveTicketTemplate(TicketTemplate ticketTemplate)
    {
        TicketTemplates.Remove(ticketTemplate);

        return ticketTemplate;
    }

    public Attendee AddAttendee(Guid attendeeId, string username, Uri? accountProfilePicture)
    {
        var attendee = Attendee.CreateInstance(attendeeId, username, accountProfilePicture);
        
        Attendees.Add(attendee);
        
        return attendee;
    }
    
    public Attendee RemoveAttendee(Attendee attendee)
    {
        Attendees.Remove(attendee);
        
        return attendee;
    }
}

