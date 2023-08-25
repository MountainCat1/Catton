using MediatR;

namespace ConventionDomain.Application.Services;

public interface ICommandMediator
{
    public Task<T> Send<T>(IRequest<T> t) where T : IRequest<T>;
}

public interface ICommandMediator<TUnitOfWork> : ICommandMediator 
    where TUnitOfWork : IUnitOfWork
{
    public Task<T> Send<T>(IRequest<T> t) where T : IRequest<T>;
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

    public async Task<T> Send<T>(IRequest<T> t) where T : IRequest<T>
    {
        var result = await _mediator.Send(t);
        await _unitOfWork.SaveChangesAsync();
        return result;
    }
}