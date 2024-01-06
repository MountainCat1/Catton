using Microsoft.AspNetCore.Mvc;
using Stripe;

[Route("webhook")]
[ApiController]
public class WebhookController : Controller
{
    // This is your Stripe CLI webhook secret for testing your endpoint locally.
    const string endpointSecret = "whsec_aa7f474a4f98899dd435d86ec7718b6d4c7fc89c68f9bfef74abfba549d56731";

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {
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