namespace Payments.Domain.ValueObjects;

public record class CheckoutSessionDetails 
{
    public string Id { get; init; }
    public string Url { get; init; }
    public DateTime ExpiresAt { get; init; }
}