using MediatR;

namespace Catut.Application.Abstractions;

public interface ICommandMediator
{
    public Task<TResult> SendAsync<TResult>(ICommand<TResult> t);
    public Task SendAsync(ICommand t);
}

public interface ICommandMediator<TUnitOfWork> : ICommandMediator 
    where TUnitOfWork : IUnitOfWork
{
}
