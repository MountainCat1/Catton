using PaymentDomain.Application.Errors;
using TicketTemplateDomain.Application.Errors;
using TicketTemplateDomain.Infrastructure.Abstractions;
using TicketTemplateDomain.Infrastructure.Errors.Database;

namespace TicketTemplateDomain.Application.Services;


public class DatabaseErrorMapper : IDatabaseErrorMapper
{
    public async Task<Exception> MapAsync(DatabaseException exception)
    {
        if (exception is ItemNotFoundException)
            return new NotFoundError(null, exception);


        return exception;
    }
}