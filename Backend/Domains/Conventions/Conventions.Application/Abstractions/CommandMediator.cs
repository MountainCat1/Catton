using MediatR;

namespace ConventionDomain.Application.Abstractions;

public interface ICommandMediator
{
    public Task<TResult> SendAsync<TResult>(ICommand<TResult> t);
    public Task SendAsync(ICommand t);
}

public interface ICommandMediator<TUnitOfWork> : ICommandMediator 
    where TUnitOfWork : IUnitOfWork
{
}

public class CommandMediator<TUnitOfWork> : ICommandMediator<TUnitOfWork>
    where TUnitOfWork : IUnitOfWork
{
    private readonly IMediator _mediator;
    private readonly TUnitOfWork _unitOfWork;
    
    public CommandMediator(IMediator mediator, TUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> SendAsync<TResult>(ICommand<TResult> t)
    {
        var result = await _mediator.Send<TResult>(t);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }

    public async Task SendAsync(ICommand t)
    {
        await _mediator.Send(t);
        await _unitOfWork.SaveChangesAsync();
    }
}