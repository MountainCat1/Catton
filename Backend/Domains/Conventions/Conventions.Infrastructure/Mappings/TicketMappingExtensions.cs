using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class TicketMappingExtensions
{
    public static TicketData ToDataEntity(this Ticket domainEntity)
    {
        return new TicketData
        {
            Id = domainEntity.Id,
            CreatedDate = domainEntity.CreatedDate,
            AttendeeId = domainEntity.AtendeeId,
            PaymentId = domainEntity.PaymentId,
            TicketTemplateId = domainEntity.TicketTemplate.Id // Assuming TicketTemplate has an Id field
        };
    }
}