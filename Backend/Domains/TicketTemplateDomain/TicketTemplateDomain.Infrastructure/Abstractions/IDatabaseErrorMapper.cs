namespace TicketTemplateDomain.Infrastructure.Abstractions;

public interface IDatabaseErrorMapper
{
    public Task<Exception> HandleAsync(DatabaseException exception);
}