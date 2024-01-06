using Catut.Application.Errors;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Errors.Database;
using Catut.Infrastructure.Exception;

namespace Catut.Application.Services;


public class DatabaseErrorMapper : IDatabaseErrorMapper
{
    public Exception Map(DatabaseException exception)
    {
        if (exception is ItemNotFoundException)
            return new NotFoundError();

        return exception;
    }
}