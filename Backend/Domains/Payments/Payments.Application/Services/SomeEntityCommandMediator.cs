using Catut.Application.Abstractions;
using Catut.Application.Services;
using MediatR;

namespace Payments.Application.Services;

public interface ISomeEntityCommandMediator : ICommandMediator<SomeEntityUnitOfWork>
{
}

public class SomeEntityCommandMediator : CommandMediator<ISomeEntityUnitOfWork>, ISomeEntityCommandMediator
{
    public SomeEntityCommandMediator(IMediator mediator, ISomeEntityUnitOfWork unitOfWork) : base(mediator, unitOfWork)
    {
    }
}