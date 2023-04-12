﻿using Catton.Utilities;
using MediatR;

namespace Account.Service.Abstractions;

public interface IResultRequest<T> : IRequest<Result<T>>
{
}

public interface IResultRequest : IRequest<Result>
{
}