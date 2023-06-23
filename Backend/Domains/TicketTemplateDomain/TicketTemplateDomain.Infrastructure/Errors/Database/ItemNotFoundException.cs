using TicketTemplateDomain.Infrastructure.Abstractions;

namespace TicketTemplateDomain.Infrastructure.Errors.Database;

public class ItemNotFoundException : DatabaseException
{
    public ItemNotFoundException()
    {
    }

    public ItemNotFoundException(string? message) : base(message)
    {
    }
}