namespace Payments.Application.Dtos.SessionDetails;

public class CheckoutSessionDetailsDto
{
    public string Id { get; set; }
    public string Url { get; set; }
    public DateTime ExpiresAt { get; set; }
}

public static class SesstionDetailsDtoExtensions
{
    public static CheckoutSessionDetailsDto ToDto(this Domain.ValueObjects.CheckoutSessionDetails checkoutSessionDetails)
    {
        return new CheckoutSessionDetailsDto
        {
            Id = checkoutSessionDetails.Id,
            Url = checkoutSessionDetails.Url,
            ExpiresAt = checkoutSessionDetails.ExpiresAt
        };
    }
}