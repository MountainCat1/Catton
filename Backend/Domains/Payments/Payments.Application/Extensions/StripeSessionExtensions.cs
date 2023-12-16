using Payments.Domain.ValueObjects;
using Stripe.Checkout;

namespace Payments.Application.Extensions;

public static class StripeSessionExtensions
{
    public static SessionDetails ToSessionDetails(this Session stripeSession)
    {
        return new SessionDetails()
        {
            Id = stripeSession.Id,
            Url = stripeSession.Url,
            ExpiresAt = stripeSession.ExpiresAt
        };
    }
}