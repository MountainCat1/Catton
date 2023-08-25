using MediatR;

namespace ConventionDomain.Application.Abstractions;


public interface ICommand : IRequest
{
}
public interface ICommand<T> : IRequest<T>, ICommand
{
}