namespace Payments.Application.Dtos.Payment;

public class PaymentUpdateDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}
