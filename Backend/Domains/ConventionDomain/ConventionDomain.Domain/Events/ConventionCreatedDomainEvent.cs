using Catut.Domain.Abstractions;
using ConventionDomain.Domain.Entities;

namespace ConventionDomain.Domain.Events;

public class ConventionCreatedDomainEvent : DomainEvent<Convention>
{
    public required Guid AccountId { get; set; }
}