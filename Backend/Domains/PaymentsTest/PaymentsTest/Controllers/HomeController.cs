using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PaymentsTest.Models;
using PaymentsTest.Settings;
using Stripe;
using Stripe.Checkout;

namespace PaymentsTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StripeSettings _stripeSettings;

    public string SessionId { get; set; }
    
    public HomeController(ILogger<HomeController> logger, IOptions<StripeSettings> stripeSettings)
    {
        _logger = logger;
        _stripeSettings = stripeSettings.Value;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Success()
    {
        return View();
    }
    
    public IActionResult Cancel()
    {
        return View();
    }
    
    public async Task<IActionResult> CreateCheckoutSession(string amount)
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
        SessionId = session.Id;
        return Redirect(session.Url);
    }
}