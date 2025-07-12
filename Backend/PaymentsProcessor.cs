namespace Backend;

public class PaymentsProcessor : BackgroundService
{
    private readonly HttpClient _defaultHttpClient;
    private readonly HttpClient _fallbackHttpClient;
    private readonly ILogger<PaymentsProcessor> _logger;

    public PaymentsProcessor(
        IConfiguration configuration,
        ILogger<PaymentsProcessor> logger,
        IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _defaultHttpClient = httpClientFactory.CreateClient();
        _fallbackHttpClient = httpClientFactory.CreateClient();

        _defaultHttpClient.BaseAddress = new Uri(configuration["PROCESSOR_DEFAULT_URL"]!);
        _fallbackHttpClient.BaseAddress = new Uri(configuration["PROCESSOR_FALLBACK_URL"]!);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var reader = PaymentsStore.Pending.Reader;

        await foreach (var payment in reader.ReadAllAsync(stoppingToken))
        {
            try
            {
                await Process(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar pagamento {id}", payment.CorrelationId);
            }
        }
    }

    private async Task Process(Payment payment)
    {
        // var defaultHealth = await _defaultHttpClient.GetFromJsonAsync<PaymentProcessorHealth>("/payments/service-health");

        var defaultResponse = await _defaultHttpClient.PostAsJsonAsync("/payments", payment);
        if (defaultResponse.IsSuccessStatusCode)
        {
            PaymentsStore.Default.Push(payment);
            return;
        }

        var fallbackResponse = await _fallbackHttpClient.PostAsJsonAsync("/payments", payment);
        if (fallbackResponse.IsSuccessStatusCode)
        {
            PaymentsStore.Fallback.Push(payment);
            return;
        }
    }
}

public class PaymentProcessorHealth
{
    public bool Health { get; set; }
    public int MinResponseTime { get; set; }
}
