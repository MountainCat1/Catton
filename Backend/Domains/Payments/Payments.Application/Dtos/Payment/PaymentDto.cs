using Payments.Application.Dtos.SessionDetails;
using Payments.Domain.Entities;

namespace Payments.Application.Dtos.Payment;

public class PaymentDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    
    public SessionDetailsDto PaymentSession { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}

public static class PaymentDtoExtensions
{
    public static PaymentDto ToDto(this Domain.Entities.Payment payment)
    {
        return new PaymentDto
        {
            Id = payment.Id,
            Amount = payment.Amount,
            PaymentSession = payment.SessionDetails.ToDto(),
            PaymentStatus = payment.PaymentStatus,
            Currency = payment.Currency,
            CreatedAt = payment.CreatedAt,
            UpdatedAt = payment.UpdatedAt
        };
    }
}