using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Stripe;
using Stripe.Checkout;

namespace Payments.Application.Services;

public interface IPaymentService
{
    /// <summary>
    /// Creates a payment session for the specified amount.
    /// </summary>
    /// <param name="amount">The amount of the payment.</param>
    /// <returns>The URL of the payment session.</returns>
    Task<(string sessionUrl, string sessionId)> CreateSessionAsync(decimal  amount);
}

public class PaymentService : IPaymentService
{
    private readonly StripeSettings _stripeSettings;

    public PaymentService(IOptions<StripeSettings> stripeSettings)
    {
        _stripeSettings = stripeSettings.Value;
    }

    
    public async Task<(string sessionUrl, string sessionId)> CreateSessionAsync(decimal amount)
    {
        var currency = "pln";
        var successUrl = "http://localhost:4242/Home/Success";
        var cancelUrl = "http://localhost:4242/Home/Cancel";
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
            CancelUrl = cancelUrl
        };

        
        var service = new SessionService();
        var session = await service.CreateAsync(options);
        // SessionId = session.Id;
        return (session.Url, session.Id);
    }
}