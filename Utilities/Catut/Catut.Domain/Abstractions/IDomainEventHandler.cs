using MediatR;

namespace Catut.Domain.Abstractions;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}