using LanguageExt.Common;
using MediatR;
using Unit = LanguageExt.Unit;

namespace Account.Application.Abstractions;

public interface IResultRequest<T> : IRequest<Result<T>>
{
}

public interface IResultRequest : IResultRequest<Unit>
{
}