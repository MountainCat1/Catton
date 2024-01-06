using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Payments.Domain.Services;
using Payments.Domain.ValueObjects;
using Stripe;
using Stripe.Checkout;

namespace Payments.Application.Services;

public interface IPaymentService
{
    /// <summary>
    /// Creates a payment session for the specified amount.
    /// </summary>
    /// <param name="amount">The amount of the payment.</param>
    /// <param name="clientReferenceId">The client reference ID.</param>
    /// <returns>The URL of the payment session.</returns>
    Task<Session> CreateSessionAsync(decimal amount, string clientReferenceId);

    /// <summary>
    /// Expires a session by setting its status to expired.
    /// </summary>
    /// <param name="sessionId">The ID of the session to expire.</param>
    /// <returns>
    /// The task result is a <see cref="Session"/> object representing the expired session.
    /// </returns>
    Task<Session> ExpireSessionAsync(string sessionId);
}

public class PaymentService : IPaymentService
{
    private readonly StripeSettings _stripeSettings;

    public PaymentService(IOptions<StripeSettings> stripeSettings)
    {
        _stripeSettings = stripeSettings.Value;
    }
    
    public async Task<Session> ExpireSessionAsync(string sessionId)
    {
        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

        var service = new SessionService();
        
        var session = await service.ExpireAsync(sessionId);

        if (session == null)
        {
            throw new Exception("Session not found");
        }

        return session;
    }

    public async Task<Session> CreateSessionAsync(decimal amount, string clientReferenceId)
    {
        var currency = "pln";
        var successUrl = _stripeSettings.SessionSettings.SuccessUrl;
        var cancelUrl = _stripeSettings.SessionSettings.CancelUrl;
        var expireIn = _stripeSettings.SessionSettings.ExpiresIn;
        var expireDate = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireIn));
        
        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

        var options = new SessionCreateOptions()
        {
            PaymentMethodTypes = new List<string>()
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>()
            {
                new SessionLineItemOptions()
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        Currency = currency,
                        UnitAmount = Convert.ToInt32(amount) * 100,
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = "Test product",
                            Description = "Test product description"
                        }
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = successUrl,
            CancelUrl = cancelUrl,
            ClientReferenceId = clientReferenceId,
            ExpiresAt = expireDate
        };


        var service = new SessionService();
        var session = await service.CreateAsync(options);
        // SessionId = session.Id;
        return session;
    }


}