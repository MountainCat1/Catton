namespace Payments.Application.Dtos.Payment
{
    public class PaymentCreateDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}