namespace Account.Domain.Abstractions;

// public interface IEntity 
// {
//     public IReadOnlyCollection<IDomainEvent>? DomainEvents { get; }
//     public void ClearDomainEvents(); 
// }

public abstract class Entity
{
    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent>? DomainEvents => _domainEvents?.AsReadOnly()!;
    
    public void AddDomainEvent<T>(DomainEvent<T> notification) where T : Entity
    {
        notification.Entity = this as T;
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(notification);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}