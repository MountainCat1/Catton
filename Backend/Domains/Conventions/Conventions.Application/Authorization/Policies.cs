namespace ConventionDomain.Application.Authorization;

public static class Policies
{
    // Conventions
    public const string ReadConvention = nameof(ReadConvention);
    public const string UpdateConvention = nameof(UpdateConvention);
    public const string ReadOneConvention = nameof(ReadOneConvention);
    
    // Organizer
    public const string ReadOrganizer = nameof(ReadOrganizer);
    public const string CreateOrganizer = nameof(CreateOrganizer);
    public const string UpdateOrganizer = nameof(UpdateOrganizer);
    public const string DeleteOrganizer = nameof(DeleteOrganizer);
    
    // Ticket templates
    public const string ReadTicketTemplates = nameof(ReadTicketTemplates);
    public const string ManageTicketTemplates = nameof(ManageTicketTemplates);
    
    // Tickets
    public const string CreateOwnTicket = nameof(CreateOwnTicket);
    public const string CreateTicket = nameof(CreateTicket);
    public const string ReadOwnTickets = nameof(ReadOwnTickets);
    public const string ReadTickets = nameof(ReadTickets);
    public const string UpdateTicket = nameof(UpdateTicket);
    public const string DeleteTicket  = nameof(DeleteTicket);
    public const string DeleteOwnTicket  = nameof(DeleteOwnTicket);
    
    // Attendees
    public const string AddAttendees = nameof(AddAttendees);
    public const string SignUpAsAttendee = nameof(SignUpAsAttendee);
    public const string ReadAttendee = nameof(ReadAttendee);
    public const string RemoveAttendee = nameof(RemoveAttendee);
}