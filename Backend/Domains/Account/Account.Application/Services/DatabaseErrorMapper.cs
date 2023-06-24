﻿using Account.Infrastructure.Generics;
using Catut.Application.Errors;
using Catut.Infrastructure.Abstractions;
using Catut.Infrastructure.Errors.Database;

namespace Account.Service.Services;


public class DatabaseErrorMapper : IDatabaseErrorMapper
{
    public async Task<Exception> MapAsync(DatabaseException exception)
    {
        if (exception is ItemNotFoundException)
            return new NotFoundError("Entity doesn't exist in the database");


        return exception;
    }
}