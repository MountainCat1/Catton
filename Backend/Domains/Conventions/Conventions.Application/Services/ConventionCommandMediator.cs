using Catut.Application.Abstractions;
using Catut.Application.Services;
using MediatR;

namespace ConventionDomain.Application.Services;

public interface IConventionCommandMediator : ICommandMediator<ConventionDomainUnitOfWork>
{
}

public class ConventionCommandMediator : CommandMediator<IConvenitonUnitOfWork>, IConventionCommandMediator
{
    public ConventionCommandMediator(IMediator mediator, IConvenitonUnitOfWork unitOfWork) : base(mediator, unitOfWork)
    {
    }
}