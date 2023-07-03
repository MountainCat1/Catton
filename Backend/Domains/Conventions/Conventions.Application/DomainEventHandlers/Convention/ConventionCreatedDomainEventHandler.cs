using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;
using Conventions.Domain.Events;

namespace ConventionDomain.Application.DomainEventHandlers.Convention;

public class ConventionCreatedDomainEventHandler : IDomainEventHandler<ConventionCreatedDomainEvent>
{
    public ConventionCreatedDomainEventHandler()
    {
    }

    public async Task Handle(ConventionCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // When new convention is created, add the creator as an organizator

        var convention = notification.Entity;
        
        var organizer = Organizer.CreateInstance(notification.Entity, notification.AccountId, OrganizerRole.Owner);

        convention.AddOrganizer(organizer);
    }
}