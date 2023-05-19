using MediatR;

namespace ConventionDomain.Domain.Abstractions;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}