namespace Backend;

public class PaymentSummaryOut
{
    public ProcessorSummaryOut Default { get; set; } = new();
    public ProcessorSummaryOut Fallback { get; set; } = new();
}

public class ProcessorSummaryOut
{
    public int TotalRequests { get; set; }
    public decimal TotalAmount { get; set; }
}
