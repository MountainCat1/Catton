using LanguageExt.Common;
using MediatR;
using Unit = LanguageExt.Unit;

namespace Account.Service.Abstractions;

public interface IResultRequest<T> : IRequest<Result<T>>
{
}

public interface IResultRequest : IResultRequest<Unit>
{
}