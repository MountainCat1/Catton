namespace TicketTemplateDomain.Infrastructure.Abstractions;

public interface IDatabaseErrorHandler
{
    Task HandleAsync(DatabaseException? exception);
}