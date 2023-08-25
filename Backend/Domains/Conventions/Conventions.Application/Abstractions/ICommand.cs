using MediatR;

namespace ConventionDomain.Application.Abstractions;

public interface ICommand<T> : IRequest<T>
{
}