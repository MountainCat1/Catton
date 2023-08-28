using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class OrganizerMappingExtensions
{
    public static OrganizerData ToDataEntity(this Organizer domainEntity)
    {
        return new OrganizerData
        {
            AccountId = domainEntity.AccountId,
            CreatedDate = domainEntity.CreatedDate,
            Role = domainEntity.Role,
            AccountUsername = domainEntity.AccountUsername,
            AccountAvatarUri = domainEntity.AccountAvatarUri
        };
    }
}