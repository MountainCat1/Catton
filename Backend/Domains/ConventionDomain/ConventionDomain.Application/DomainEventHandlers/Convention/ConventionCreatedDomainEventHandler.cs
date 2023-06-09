using ConventionDomain.Domain.Abstractions;
using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Events;
using ConventionDomain.Domain.Repositories;

namespace ConventionDomain.Application.DomainEventHandlers.Convention;

public class ConventionCreatedDomainEventHandler : IDomainEventHandler<ConventionCreatedDomainEvent>
{
    private IOrganizerRepository _repository;

    public ConventionCreatedDomainEventHandler(IOrganizerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ConventionCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // When new convention is created, add the creator as an organizator

        var organizer = Organizer.CreateInstance(notification.Entity, notification.AccountId, OrganizerRole.Owner);

        await _repository.AddAsync(organizer);
    }
}