using OpenApi.Accounts;
using OpenApi.Conventions;

namespace Initializator;

public class InitializationSettings
{
    public CreatePasswordAccountRequestContract Admin { get; set; }
    public ConventionCreateDto Convention { get; set; }
    public ICollection<CreatePasswordAccountRequestContract> Accounts { get; set; }
    public ICollection<OrganizerCreateDto> Organizers { get; set; }
    public ICollection<TicketTemplateCreateDto> TicketTemplates { get; set; }
    
}