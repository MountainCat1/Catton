namespace Payments.Domain.ValueObjects;

public record class SessionDetails 
{
    public string Id { get; init; }
    public string Url { get; init; }
    public DateTime ExpiresAt { get; init; }
}