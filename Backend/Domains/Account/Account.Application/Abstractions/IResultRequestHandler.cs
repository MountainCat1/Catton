using LanguageExt.Common;
using MediatR;

namespace Account.Application.Abstractions;

public interface IResultRequestHandler<TResultRequest, TResult> 
    : IRequestHandler<TResultRequest, Result<TResult>> 
    where TResultRequest : IResultRequest<TResult>
{
}