using LanguageExt.Common;
using MediatR;

namespace Account.Application.Abstractions;

public interface IResultRequest<T> : IRequest<Result<T>>
{
}