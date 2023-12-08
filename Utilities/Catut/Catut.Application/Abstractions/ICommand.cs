using MediatR;

namespace Catut.Application.Abstractions;


public interface ICommand : IRequest
{
}
public interface ICommand<T> : IRequest<T>, ICommand
{
}