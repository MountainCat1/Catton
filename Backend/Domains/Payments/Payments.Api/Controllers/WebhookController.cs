using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Stripe;

namespace Payments.Api.Controllers;

[Route("webhook")]
[ApiController]
public class WebhookController : Controller
{
    private readonly StripeSettings _stripeSettings;

    public WebhookController(IOptions<StripeSettings> stripeSettings)
    {
        _stripeSettings = stripeSettings.Value;
    }

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {
            var endpointSecret = _stripeSettings.EndpointSecret;
            
            var stripeEvent = EventUtility.ConstructEvent(json,
                Request.Headers["Stripe-Signature"], endpointSecret);

            // Handle the event
            if (stripeEvent.Type == Events.PaymentIntentSucceeded)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                Console.WriteLine("PaymentIntent was successful!");
                Console.WriteLine("PaymentIntent ID: {0}", paymentIntent.Id);
            }
            // ... handle other event types
            else
            {
                Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
            }

            return Ok();
        }
        catch (StripeException e)
        {
            return BadRequest();
        }
    }
}