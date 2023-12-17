using Payments.Domain.ValueObjects;
using Stripe.Checkout;

namespace Payments.Application.Extensions;

public static class StripeSessionExtensions
{
    public static CheckoutSessionDetails ToSessionDetails(this Session stripeSession)
    {
        return new CheckoutSessionDetails()
        {
            Id = stripeSession.Id,
            Url = stripeSession.Url,
            ExpiresAt = stripeSession.ExpiresAt
        };
    }
}