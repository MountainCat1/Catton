using Catut.Application.Abstractions;
using Catut.Application.Services;
using MediatR;

namespace Payments.Application.Services;

public interface IPaymentCommandMediator : ICommandMediator<PaymentUnitOfWork>
{
}

public class PaymentCommandMediator : CommandMediator<IPaymentUnitOfWork>, IPaymentCommandMediator
{
    public PaymentCommandMediator(IMediator mediator, IPaymentUnitOfWork unitOfWork) : base(mediator, unitOfWork)
    {
    }
}