using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class AttendeeMappingExtensions
{
    public static AttendeeData ToDataEntity(this Attendee domainEntity)
    {
        return new AttendeeData
        {
            AccountId = domainEntity.AccountId,
            CreatedDate = domainEntity.CreatedDate,
            AccountUsername = domainEntity.AccountUsername,
            AccountAvatarUri = domainEntity.AccountAvatarUri,
            Tickets = domainEntity.Tickets.Select(t => t.ToDataEntity()).ToList()
        };
    }
}