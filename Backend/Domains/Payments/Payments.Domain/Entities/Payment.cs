using System.Xml.Resolvers;
using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Payments.Domain.Services;
using Payments.Domain.Validators;
using Payments.Domain.ValueObjects;

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
    
    public CheckoutSessionDetails CheckoutSession { get; set; } = null!;

    public PaymentStatus PaymentStatus { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;

    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }

    private readonly PaymentValidator _paymentValidator;
    
    private readonly object _lock = new object();

    private Payment()
    {
        _paymentValidator = new PaymentValidator();
    }
    
    public static Payment CreateInstance(
        decimal amount,
        string currency)
    {
        var newInstance = new Payment
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            Currency = currency,
            PaymentStatus = PaymentStatus.Pending, // Initial status
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        newInstance.ValidateAndThrow();

        return newInstance;
    }

    public void SetSession(CheckoutSessionDetails checkoutSessionDetails)
    {
        CheckoutSession = checkoutSessionDetails;
        
        ValidateAndThrow();
    }
    
    public void UpdateStatus(PaymentStatus status)
    {
        PaymentStatus = status;
        UpdatedAt = DateTime.UtcNow;
        
        ValidateAndThrow();
    }
    
    public async Task RenewPaymentSessionAsync(ISessionDomainService sessionDomainService)
    {
        if(CheckoutSession == null)
            throw new InvalidOperationException("Session details must be set before renewing session.");
        
        if (PaymentStatus != PaymentStatus.Failed && PaymentStatus != PaymentStatus.Pending)
        {
            throw new InvalidOperationException("Can only renew sessions for failed or pending payments.");
        }
        
        await sessionDomainService.ExpireSessionAsync(CheckoutSession.Id); 
        
        var newSessionDetails = await sessionDomainService.CreateSessionAsync(Amount, Currency);
        SetSession(newSessionDetails);
        
        if (PaymentStatus == PaymentStatus.Failed)
        {
            UpdateStatus(PaymentStatus.Pending);
        }
    }
    
    public void ValidateAndThrow()
    {
        var result = _paymentValidator.Validate(this);
        
        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}