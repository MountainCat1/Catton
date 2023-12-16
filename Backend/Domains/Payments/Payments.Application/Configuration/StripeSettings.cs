namespace Payments.Application.Configuration;

public class StripeSettings
{
    public string SecretKey { get; set; }
    public string PublicKey { get; set; }

    public string EndpointSecret { get; set; }
}