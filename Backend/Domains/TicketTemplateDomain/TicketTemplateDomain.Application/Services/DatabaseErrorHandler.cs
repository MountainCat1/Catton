using TicketTemplateDomain.Application.Errors;
using TicketTemplateDomain.Infrastructure.Abstractions;
using TicketTemplateDomain.Infrastructure.Errors.Database;

namespace TicketTemplateDomain.Application.Services;


public class DatabaseErrorHandler : IDatabaseErrorHandler
{
    public Task HandleAsync(DatabaseException? exception)
    {
        if(exception is null)
            return Task.CompletedTask;
        
        if (exception is ItemNotFoundException)
            throw new NotFoundError(null, exception);


        throw exception;
    }
}