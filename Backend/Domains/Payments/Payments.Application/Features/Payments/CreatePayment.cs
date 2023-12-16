using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Domain.Errors;
using MediatR;
using Payments.Application.Dtos.Payment;
using Payments.Application.Extensions;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Stripe.Checkout;

namespace Payments.Application.Features.Payments;

public class CreatePaymentCommand : ICommand<PaymentDto>
{
    public required PaymentCreateDto PaymentCreateDto { get; init; }
}

public class CreatePaymentRequestHandler : IRequestHandler<CreatePaymentCommand, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPaymentService _paymentService;

    public CreatePaymentRequestHandler(IPaymentRepository paymentRepository, IPaymentService paymentService)
    {
        _paymentRepository = paymentRepository;
        _paymentService = paymentService;
    }

    public async Task<PaymentDto> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
    {
        var dto = command.PaymentCreateDto;

        Payment payment;

        try
        {
            payment = Payment.CreateInstance(
                amount: dto.Amount,
                currency: dto.Currency);
        }
        catch (ConflictDomainError e)
        {
            // Convention already exists
            throw new BadRequestError(e.Message);
        }
        
        Session session = await _paymentService.CreateSessionAsync(command.PaymentCreateDto.Amount, payment.Id.ToString());

        var sessionDetails = session.ToSessionDetails();
        
        payment.SetSession(sessionDetails);
        
        await _paymentRepository.AddAsync(payment);

        return payment.ToDto();
    }
}