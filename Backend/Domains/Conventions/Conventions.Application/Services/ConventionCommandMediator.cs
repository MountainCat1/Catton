using MediatR;

namespace ConventionDomain.Application.Services;

public interface IConventionCommandMediator
{
    Task<T> Send<T>(IRequest<T> t) where T : IRequest<T>;
}

public class ConventionCommandMediator : CommandMediator<IConvenitonUnitOfWork>, IConventionCommandMediator
{
    public ConventionCommandMediator(IMediator mediator, IConvenitonUnitOfWork unitOfWork) : base(mediator, unitOfWork)
    {
    }
}