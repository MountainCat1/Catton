using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;
using Conventions.Domain.Events;
using Conventions.Domain.Repositories;

namespace Conventions.Application.DomainEventHandlers.Convention;

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