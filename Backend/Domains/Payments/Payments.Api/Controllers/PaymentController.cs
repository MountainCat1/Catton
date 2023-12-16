using Catut.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Payments.Application.Dtos.Payment;
using Payments.Application.Features.Payments;
using Payments.Application.Services;
using Stripe;
using Stripe.Checkout;

namespace Payments.Api.Controllers;

[Route("payments")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly StripeSettings _stripeSettings;

    private readonly IPaymentCommandMediator _commandMediator;

    public PaymentController(IOptions<StripeSettings> stripeSettings, IPaymentCommandMediator commandMediator)
    {
        _commandMediator = commandMediator;
        _stripeSettings = stripeSettings.Value;
    }

    public string SessionId { get; set; }


    [HttpPost]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateDto createDto)
    {
        var command = new CreatePaymentCommand()
        {
            PaymentCreateDto = createDto
        };

        var result = await _commandMediator.SendAsync(command);

        return Ok(result);
    }

    // [HttpPost]
    // public async Task<IActionResult> CreateCheckoutSession(string amount)
    // {
    //     var currency = "pln";
    //     var successUrl = "http://localhost:4242/Home/Success";
    //     var cancelUrl = "http://localhost:4242/Home/Cancel";
    //     StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
    //
    //     var options = new SessionCreateOptions()
    //     {
    //         PaymentMethodTypes = new List<string>()
    //         {
    //             "card"
    //         },
    //         LineItems = new List<SessionLineItemOptions>()
    //         {
    //             new SessionLineItemOptions()
    //             {
    //                 PriceData = new SessionLineItemPriceDataOptions()
    //                 {
    //                     Currency = currency,
    //                     UnitAmount = Convert.ToInt32(amount) * 100,
    //                     ProductData = new SessionLineItemPriceDataProductDataOptions()
    //                     {
    //                         Name = "Test product",
    //                         Description = "Test product description"
    //                     }
    //                 },
    //                 Quantity = 1
    //             }
    //         },
    //         Mode = "payment",
    //         SuccessUrl = successUrl,
    //         CancelUrl = cancelUrl
    //     };
    //
    //     var service = new SessionService();
    //     var session = await service.CreateAsync(options);
    //     SessionId = session.Id;
    //     return Ok(session.Url);
    // }
}