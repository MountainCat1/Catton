namespace Catut.Application.Abstractions;

public interface IQueryMediator
{
    Task<TResult> SendAsync<TResult>(IQuery<TResult> query);
}

