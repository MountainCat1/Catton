using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Domain.Errors;
using MediatR;
using Payments.Application.Dtos.Payment;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;

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

        var (sessionUrl, sessionId) = await _paymentService.CreateSessionAsync(command.PaymentCreateDto.Amount);

        try
        {
            payment = Payment.CreateInstance(
                stripeSessionId: sessionId,
                amount: dto.Amount,
                currency: dto.Currency,
                sessiopUrl: sessionUrl);
        }
        catch (ConflictDomainError e)
        {
            // Convention already exists
            throw new BadRequestError(e.Message);
        }
        
        await _paymentRepository.AddAsync(payment);

        return payment.ToDto();
    }
}