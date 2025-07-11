using System.Net;
using System.Net.Http.Json;

namespace Tests.Base;

public class BackendHttpClient(HttpClient http)
{
    public readonly HttpClient Http = http;

    public async Task<HttpResponseMessage> PostPayment(Guid correlationId, decimal amount)
    {
        var input = new PaymentIn { CorrelationId = correlationId, Amount = amount };

        return await Http.PostAsJsonAsync("/payments", input);
    }

    public async Task<PaymentSummaryOut> GetPaymentsSummary(DateTime? from, DateTime? to)
    {
        var fromParam = from != null ? WebUtility.UrlEncode(from.Value.ToString("o")) : null;
        var toParam = to != null ? WebUtility.UrlEncode(to.Value.ToString("o")) : null;

        var fromQuery = fromParam != null ? $"from={fromParam}" : null;
        var toQuery = toParam != null ? $"&to={toParam}" : null;

        return await Http.GetFromJsonAsync<PaymentSummaryOut>($"/payments-summary?{fromQuery}{toQuery}") ?? new();
    }
}
