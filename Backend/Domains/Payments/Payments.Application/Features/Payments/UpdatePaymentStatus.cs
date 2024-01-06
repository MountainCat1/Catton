using Catut.Application.Abstractions;
using Catut.Application.Errors;
using MassTransit;
using MediatR;
using Payments.Application.Dtos.Payment;
using Payments.Application.Messages;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;

namespace Payments.Application.Features.Payments;

public class UpdatePaymentStatusCommand : ICommand<PaymentDto>
{
    public required Guid PaymentId { get; init; }
    public required PaymentStatus Status { get; init; }
}

public class UpdatePaymentRequestHandler : IRequestHandler<UpdatePaymentStatusCommand, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPaymentService _paymentService;
    private readonly IBusControl _busControl;

    public UpdatePaymentRequestHandler(
        IPaymentRepository paymentRepository,
        IPaymentService paymentService,
        IBusControl busControl)
    {
        _paymentRepository = paymentRepository;
        _paymentService = paymentService;
        _busControl = busControl;
    }

    public async Task<PaymentDto> Handle(UpdatePaymentStatusCommand command, CancellationToken ct)
    {
        // Get the payment with the specified ID.
        var payment = await _paymentRepository.GetOneRequiredAsync(command.PaymentId);

        if (payment == null)
        {
            // Throw an exception or handle this scenario as appropriate for your application.
            throw new NotFoundError($"No payment found with ID {command.PaymentId}");
        }

        // Update the payment status.
        payment.PaymentStatus = command.Status;

        await _busControl.Publish(new PaymentUpdatedMessage(), ct);

        // Return the updated payment as a DTO.
        return payment.ToDto();
    }
}