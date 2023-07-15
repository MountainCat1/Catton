namespace ConventionDomain.Application.Authorization;

public static class Policies
{
    public const string ReadConvention = nameof(ReadConvention);
    
    
    public const string ReadOrganizer = nameof(ReadOrganizer);
    public const string CreateOrganizer = nameof(CreateOrganizer);
    public const string UpdateOrganizer = nameof(UpdateOrganizer);
    public const string DeleteOrganizer = nameof(DeleteOrganizer);
    public const string UpdateConvention = nameof(UpdateConvention);
    
    public const string ReadTicketTemplates = nameof(ReadTicketTemplates);
    public const string ManageTicketTemplates = nameof(ManageTicketTemplates);
}