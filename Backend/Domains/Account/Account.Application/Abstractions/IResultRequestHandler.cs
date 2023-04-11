using LanguageExt.Common;
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
    : IRequestHandler<TResultRequest, Result<LanguageExt.Unit>>, IResultRequestHandler 
    where TResultRequest : IResultRequest<LanguageExt.Unit>
{
}