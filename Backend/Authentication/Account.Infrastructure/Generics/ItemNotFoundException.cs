﻿using System;

namespace Account.Infrastructure.Generics;

public class ItemNotFoundException : Exception
{
    public ItemNotFoundException()
    {
    }

    public ItemNotFoundException(string? message) : base(message)
    {
    }
}