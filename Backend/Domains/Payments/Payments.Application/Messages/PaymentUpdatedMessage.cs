using Payments.Application.Dtos.Payment;

namespace Payments.Application.Messages;

public class PaymentUpdatedMessage
{
    public Guid Id { get; set; }
    public PaymentDto Dto { get; set; }
}