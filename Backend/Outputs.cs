namespace Backend;

public class PaymentSummaryOut
{
    public ProcessorSummaryOut Default { get; set; }
    public ProcessorSummaryOut Fallback { get; set; }
}

public class ProcessorSummaryOut
{
    public int TotalRequests { get; set; }
    public decimal TotalAmount { get; set; }
}
