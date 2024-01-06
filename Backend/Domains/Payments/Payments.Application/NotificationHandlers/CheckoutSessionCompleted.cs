using MediatR;
using Payments.Application.Features.Payments;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Stripe;
using Stripe.Checkout;

namespace Payments.Application.NotificationHandlers;

public class CheckoutSessionCompleted : INotification
{
    public required Session Session { get; init; }
}

public class PaymentSuccesfulHandler : INotificationHandler<CheckoutSessionCompleted>
{
    private readonly IPaymentCommandMediator _paymentCommandMediator;
    private readonly IPaymentRepository _paymentRepository;

    public PaymentSuccesfulHandler(IPaymentCommandMediator mediator, IPaymentRepository paymentRepository)
    {
        _paymentCommandMediator = mediator;
        _paymentRepository = paymentRepository;
    }

    public async Task Handle(CheckoutSessionCompleted notification, CancellationToken ct)
    {
        var session = notification.Session;
        
        var payment = await _paymentRepository.GetOneRequiredAsync(x => x.CheckoutSession.Id == session.Id);
        
        var command = new UpdatePaymentStatusCommand()
        {
            PaymentId = payment.Id,
            Status = PaymentStatus.Succeeded
        };

        await _paymentCommandMediator.SendAsync(command);
    }
}