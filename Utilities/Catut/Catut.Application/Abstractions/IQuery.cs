using MediatR;

namespace Catut.Application.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>
{
}