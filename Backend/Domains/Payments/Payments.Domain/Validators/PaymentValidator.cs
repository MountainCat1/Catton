using System.Security.Cryptography;
using FluentValidation;
using Payments.Domain.Entities;

namespace Payments.Domain.Validators;

public class PaymentValidator : AbstractValidator<Payment>
{
    public PaymentValidator()
    {
        RuleFor(payment => payment.Amount).GreaterThan(0);
        RuleFor(payment => payment.Currency).NotEmpty();

        RuleFor(payment => payment.Id).NotEmpty().NotNull();
        RuleFor(payment => payment.PaymentStatus).NotNull();

        RuleFor(payment => payment.Amount).PrecisionScale(10, 2, true);
    }
}