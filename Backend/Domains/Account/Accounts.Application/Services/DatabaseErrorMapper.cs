using Catut.Application.Errors;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Errors.Database;

namespace Accounts.Service.Services;


public class DatabaseErrorMapper : IDatabaseErrorMapper
{
    public Exception Map(DatabaseException exception)
    {
        if (exception is ItemNotFoundException)
            return new NotFoundError("Entity doesn't exist in the database");


        return exception;
    }
}