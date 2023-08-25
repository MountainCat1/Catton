using MediatR;

namespace ConventionDomain.Application.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>
{
}