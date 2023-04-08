using Account.Domain.DomainEvents;
using MediatR;

namespace Account.Application;

public class SomeDomainEventHandler : INotificationHandler<CreateAccountDomainEvent>
{
    public async Task Handle(CreateAccountDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine(notification.Entity);
    }
}