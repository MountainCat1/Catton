namespace Payments.Application.Configuration;

public class StripeSettings
{
    public string SecretKey { get; set; }
    public string PublicKey { get; set; }

    public string EndpointSecret { get; set; }

    public StripeSessionSettings SessionSettings { get; set; }
}

public class StripeSessionSettings
{
    public string SuccessUrl { get; set; }
    public string CancelUrl { get; set; }
    public string ExpiresIn { get; set; }
}