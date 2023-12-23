using Catut.Application.Abstractions;
using Catut.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Payments.Application.Configuration;
using Payments.Application.Dtos.Payment;
using Payments.Application.Dtos.SessionDetails;
using Payments.Application.Features.Payments;
using Payments.Application.Services;
using Stripe;
using Stripe.Checkout;
using GetPaymentQuery = Payments.Application.Features.Payments.GetPaymentQuery;

namespace Payments.Api.Controllers;

[Route("api/payments")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly StripeSettings _stripeSettings;

    private readonly IPaymentCommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public PaymentController(IOptions<StripeSettings> stripeSettings, IPaymentCommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
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
    
    [HttpGet("{paymentId}")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPayment([FromRoute] Guid paymentId)
    {
        var query = new GetPaymentQuery()
        {
            PaymentId = paymentId
        };

        var result = await _queryMediator.SendAsync(query);

        return Ok(result);
    }
    
    [HttpPost("{paymentId}/checkout-session")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PaymentDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCheckoutSession([FromRoute] Guid paymentId)
    {
        var query = new RenewPaymentStatusCommand()
        {
            PaymentId = paymentId
        };

        var result = await _commandMediator.SendAsync(query);

        return Ok(result);
    }
}