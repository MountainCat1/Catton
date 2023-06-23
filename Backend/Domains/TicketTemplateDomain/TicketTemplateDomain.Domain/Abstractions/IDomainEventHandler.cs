using MediatR;

namespace TicketTemplateDomain.Domain.Abstractions;

public interface IDomainEventHandler<T> : INotificationHandler<T> where T : IDomainEvent
{
}