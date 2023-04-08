using MediatR;

namespace Account.Domain.Abstractions;

public interface IDomainEvent : INotification
{
}

public abstract class DomainEvent<TEntity> : IDomainEvent where TEntity : IEntity
{
    public TEntity Entity { get; set; }
}
