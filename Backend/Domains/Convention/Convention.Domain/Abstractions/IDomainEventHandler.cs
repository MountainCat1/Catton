using MediatR;

namespace Convention.Domain.Abstractions;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}