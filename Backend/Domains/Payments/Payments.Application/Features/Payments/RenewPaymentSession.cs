using Catut.Application.Abstractions;
using Catut.Application.Errors;
using MediatR;
using Payments.Application.Dtos.Payment;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using Payments.Domain.Services;

namespace Payments.Application.Features.Payments;

public class RenewPaymentStatusCommand : ICommand<PaymentDto>
{
    public required Guid PaymentId { get; init; }
}

public class RenewPaymentRequestHandler : IRequestHandler<RenewPaymentStatusCommand, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPaymentService _paymentService;
    private readonly ISessionDomainService _sessionDomainService;

    public RenewPaymentRequestHandler(IPaymentRepository paymentRepository, IPaymentService paymentService, ISessionDomainService sessionDomainService)
    {
        _paymentRepository = paymentRepository;
        _paymentService = paymentService;
        _sessionDomainService = sessionDomainService;
    }

    public async Task<PaymentDto> Handle(RenewPaymentStatusCommand command, CancellationToken cancellationToken)
    {
        // Get the payment with the specified ID.
        var payment = await _paymentRepository.GetOneRequiredAsync(command.PaymentId);

        if (payment == null)
        {
            // Throw an exception or handle this scenario as appropriate for your application.
            throw new NotFoundError($"No payment found with ID {command.PaymentId}");
        }
        
        await payment.RenewPaymentSessionAsync(_sessionDomainService);

        // Return the updated payment as a DTO.
        return payment.ToDto();
    }
}