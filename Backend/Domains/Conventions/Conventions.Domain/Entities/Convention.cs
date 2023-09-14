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

    private readonly List<Organizer> _organizers = new();
    private readonly List<TicketTemplate> _ticketTemplates = new();
    private readonly List<Attendee> _attendees = new();

    public IReadOnlyCollection<Organizer> Organizers => _organizers.AsReadOnly();
    public IReadOnlyCollection<TicketTemplate> TicketTemplates => _ticketTemplates.AsReadOnly();
    public IReadOnlyCollection<Attendee> Attendees => _attendees.AsReadOnly();


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

    public Organizer AddOrganizer(
        Guid accountId,
        string accountUsername,
        OrganizerRole role = OrganizerRole.Helper,
        Uri? accountProfilePicture = null)
    {
        var organizer = Organizer.CreateInstance(
            accountId: accountId,
            accountUsername: accountUsername,
            convention: this,
            accountProfilePicture: accountProfilePicture,
            role: role);

        _organizers.Add(organizer);

        return organizer;
    }

    public Organizer? RemoveOrganizer(Guid organizerId)
    {
        var organizerToRemove = Organizers.FirstOrDefault(x => x.AccountId == organizerId);

        if (organizerToRemove is null)
            return null;

        _organizers.Remove(organizerToRemove);

        return organizerToRemove;
    }

    public TicketTemplate AddTicketTemplate(
        string name,
        string description,
        decimal price,
        Guid authoriId)
    {
        var ticketTemplate = TicketTemplate.Create(
            name: name,
            description: description,
            price: price,
            authorId: authoriId);

        _ticketTemplates.Add(ticketTemplate);

        return ticketTemplate;
    }

    public TicketTemplate RemoveTicketTemplate(TicketTemplate ticketTemplate)
    {
        _ticketTemplates.Remove(ticketTemplate);

        return ticketTemplate;
    }

    public Attendee AddAttendee(Guid accountId, string accountUsername, Uri? accountProfilePicture)
    {
        if (Attendees.Any(x => x.AccountId == accountId))
            throw new InvalidOperationException($"Cannot add new attendee with specified account ID, account already assigned");
        
        var attendee = Attendee.CreateInstance(
            accountId: accountId,
            accountUsername: accountUsername,
            accountProfilePicture: accountProfilePicture);
        
        _attendees.Add(attendee);

        return attendee;
    }

    public Attendee RemoveAttendee(Attendee attendee)
    {
        _attendees.Remove(attendee);

        return attendee;
    }
}