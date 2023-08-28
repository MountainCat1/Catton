using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class ConventionMappingExtensions
{
    public static ConventionData ToDataEntity(this Convention domainEntity)
    {
        return new ConventionData
        {
            Id = domainEntity.Id,
            Name = domainEntity.Name,
            Description = domainEntity.Description,
            CreatedDate = domainEntity.CreatedDate,
            Active = domainEntity.Active,
            Organizers = domainEntity.Organizers.Select(o => o.ToDataEntity()).ToList(),
            TicketTemplates = domainEntity.TicketTemplates.Select(t => t.ToDataEntity()).ToList(),
            Attendees = domainEntity.Attendees.Select(a => a.ToDataEntity()).ToList()
        };
    }
}