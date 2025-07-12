namespace Backend;

public class Payment
{
    public Guid CorrelationId { get; set; }
    public decimal Amount { get; set; }
    public DateTime RequestedAt { get; set; }

    public Payment(PaymentIn input)
    {
        CorrelationId = input.CorrelationId;
        Amount = input.Amount;
        RequestedAt = DateTime.UtcNow;
    }
}
