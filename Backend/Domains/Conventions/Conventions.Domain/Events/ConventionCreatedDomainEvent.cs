using Catut.Domain.Abstractions;
using Conventions.Domain.Entities;

namespace Conventions.Domain.Events;

public class ConventionCreatedDomainEvent : DomainEvent<Convention>
{
    public required Guid AccountId { get; set; }
}