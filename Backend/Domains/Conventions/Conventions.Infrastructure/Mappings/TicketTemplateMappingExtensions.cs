using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class TicketTemplateMappingExtensions
{
    public static TicketTemplateData ToDataEntity(this TicketTemplate domainEntity)
    {
        return new TicketTemplateData
        {
            Id = domainEntity.Id,
            Name = domainEntity.Name,
            Description = domainEntity.Description,
            Price = domainEntity.Price,
            Available = domainEntity.Avaliable,
            CreateDate = domainEntity.CreateDate,
            LastUpdateDate = domainEntity.LastUpdateDate,
            AuthorId = domainEntity.AuthorId,
            LastEditAuthorId = domainEntity.LastEditAuthorId
        };
    }
}