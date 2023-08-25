using ConventionDomain.Application.Abstractions;
using MediatR;

namespace ConventionDomain.Application.Services;

public class QueryMediator : IQueryMediator
{
    private readonly IMediator _mediator;

    public QueryMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<TResult> SendAsync<TResult>(IQuery<TResult> query)
    {
        return await _mediator.Send(query);
    }
}