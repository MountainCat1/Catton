using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Payments.Domain.Validators;

namespace Payments.Domain.Entities;

public enum PaymentStatus
{
    Pending,
    Succeeded,
    Failed
}

public class Payment : Entity
{
    public Guid Id { get; set; }
    
    public string StripeSessionId { get; set; }
    public string SessionUrl { get; set; }

    public PaymentStatus PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public DateTime CreatedAt { get; set; } 
    public DateTime? UpdatedAt { get; set; }

    public static Payment CreateInstance(string stripeSessionId, decimal amount, string currency, string sessiopUrl)
    {
        var newInstance = new Payment
        {
            Id = Guid.NewGuid(),
            StripeSessionId = stripeSessionId,
            Amount = amount,
            Currency = currency,
            PaymentStatus = PaymentStatus.Pending, // Initial status
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null,
            SessionUrl = sessiopUrl
        };

        newInstance.ValidateAndThrow();

        return newInstance;
    }
    
    public void ValidateAndThrow()
    {
        var result = new PaymentValidator().Validate(this);
        
        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}