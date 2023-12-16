using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Payments.Application.NotificationHandlers;
using Stripe;
using Stripe.Checkout;

namespace Payments.Api.Controllers;

[Route("webhook")]
[ApiController]
public class WebhookController : Controller
{
    private readonly StripeSettings _stripeSettings;
    private IMediator _mediator;

    public WebhookController(IOptions<StripeSettings> stripeSettings, IMediator mediator)
    {
        _mediator = mediator;
        _stripeSettings = stripeSettings.Value;
    }

    [HttpPost]
    public async Task<IActionResult> StripeWebhook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        try
        {
            var endpointSecret = _stripeSettings.EndpointSecret;
            
            var stripeEvent = EventUtility.ConstructEvent(json,
                Request.Headers["Stripe-Signature"], endpointSecret);
            
            Console.WriteLine("Received event: {0}", stripeEvent.Type);

            return await HandleStripeEventAsync(stripeEvent);
        }
        catch (StripeException e)
        {
            return BadRequest();
        }
    }

    private async Task<IActionResult> HandleStripeEventAsync(Event stripeEvent)
    {
        INotification? notification = null;
        
        // Handle the specific event type
        switch (stripeEvent.Type)
        {
            case Events.CheckoutSessionCompleted:
                var session = (Session)stripeEvent.Data.Object;

                notification = new CheckoutSessionCompleted()
                {
                    Session = session,
                };
                
                // var orderSessionID = session.ClientReferenceId;
                break;
            default:
                Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                break;
            
        }
        
        if(notification is null)
            return NoContent();

        await _mediator.Publish(notification);

        return Ok();
    }
}