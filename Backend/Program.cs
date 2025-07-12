using Backend;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddHostedService<PaymentsProcessor>();

var app = builder.Build();

app.MapPost("/payments", ([FromBody] PaymentIn input) =>
{
    PaymentsStore.Pending.Writer.TryWrite(new(input));

    return Results.Ok(new { });
});

app.MapGet("/payments-summary", ([AsParameters] PaymentSummaryIn input) =>
{
    var result = new PaymentSummaryOut();

    result.Default.TotalRequests = PaymentsStore.Default.Count(x => x.RequestedAt >= input.From && x.RequestedAt <= input.To);
    result.Default.TotalAmount = PaymentsStore.Default.Where(x => x.RequestedAt >= input.From && x.RequestedAt <= input.To).Sum(x => x.Amount);

    result.Fallback.TotalRequests = PaymentsStore.Fallback.Count(x => x.RequestedAt >= input.From && x.RequestedAt <= input.To);
    result.Fallback.TotalAmount = PaymentsStore.Fallback.Where(x => x.RequestedAt >= input.From && x.RequestedAt <= input.To).Sum(x => x.Amount);

    return Results.Ok(result);
});

app.Run();

public partial class Program { }
