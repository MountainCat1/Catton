using Catton.Utilities;
using MediatR;

namespace Account.Service.Abstractions;

public interface IResultRequestHandler
{
    
}

public interface IResultRequestHandler<TResultRequest, TResult> 
    : IRequestHandler<TResultRequest, Result<TResult>>, IResultRequestHandler
    where TResultRequest : IResultRequest<TResult>
{
}

public interface IResultRequestHandler<TResultRequest> 
    : IRequestHandler<TResultRequest, Result<Unit>>, IResultRequestHandler 
    where TResultRequest : IResultRequest<Unit>
{
}