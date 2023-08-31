using AutoMapper;
using Conventions.Domain.Entities;
using Conventions.Infrastructure.DataEntities;

namespace Conventions.Infrastructure.Mappings;

public static class ConventionMappingExtensions
{
    public static ConventionData ToData(this Convention domainEntity)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ConventionMappingProfile>();
        });

        return config.CreateMapper().Map<ConventionData>(domainEntity);
    } 
    
    public static Convention ToDomain(this ConventionData dataEntity)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ConventionMappingProfile>();
        });

        return config.CreateMapper().Map<Convention>(dataEntity);
    } 
}

public class ConventionMappingProfile : Profile
{
    public ConventionMappingProfile()
    {
        CreateMap<Convention, ConventionData>();
        CreateMap<ConventionData, Convention>();
        
        CreateMap<OrganizerData, Organizer>();
        CreateMap<Organizer, OrganizerData>();
        
        CreateMap<TicketTemplateData, TicketTemplate>();
        CreateMap<TicketTemplate, TicketTemplateData>();
    }
}
