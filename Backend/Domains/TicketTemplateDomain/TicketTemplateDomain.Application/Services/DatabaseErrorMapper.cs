using TicketTemplateDomain.Application.Errors;
using TicketTemplateDomain.Infrastructure.Abstractions;
using TicketTemplateDomain.Infrastructure.Errors.Database;

namespace TicketTemplateDomain.Application.Services;


public class DatabaseErrorMapper : IDatabaseErrorMapper
{
    public async Task<Exception> HandleAsync(DatabaseException exception)
    {
        if (exception is ItemNotFoundException)
            return new NotFoundError(null, exception);


        return exception;
    }
}