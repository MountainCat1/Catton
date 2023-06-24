using MediatR;

namespace Catut.Domain.Abstractions;

public interface IDomainEvent : INotification
{
}

public abstract class DomainEvent : IDomainEvent
{
}

public abstract class DomainEvent<TEntity> : DomainEvent where TEntity : Entity
{
    public TEntity Entity { get; set; }
}
