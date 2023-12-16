using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Domain.Errors;
using MediatR;
using Payments.Application.Dtos.Payment;
using Payments.Application.Services;
using Payments.Domain.Entities;
using Payments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Payments.Application.Features.Payments;

public class GetPaymentQuery : IQuery<PaymentDto>
{
    public required Guid PaymentId { get; init; }
}

public class GetPaymentRequestHandler : IRequestHandler<GetPaymentQuery, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPaymentService _paymentService;

    public GetPaymentRequestHandler(IPaymentRepository paymentRepository, IPaymentService paymentService)
    {
        _paymentRepository = paymentRepository;
        _paymentService = paymentService;
    }

    public async Task<PaymentDto> Handle(GetPaymentQuery command, CancellationToken cancellationToken)
    {
        // Get the payment with the specified ID.
        var payment = await _paymentRepository.GetOneRequiredAsync(command.PaymentId);
        
        if (payment == null)
        {
            // Throw an exception or handle this scenario as appropriate for your application.
            throw new NotFoundError($"No payment found with ID {command.PaymentId}");
        }

        // Return the updated payment as a DTO.
        return payment.ToDto();
    }
}