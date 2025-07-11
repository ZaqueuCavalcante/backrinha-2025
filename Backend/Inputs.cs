namespace Backend;

public class PaymentIn
{
    public Guid CorrelationId { get; set; }
    public decimal Amount { get; set; }
}

public class PaymentSummaryIn
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}
