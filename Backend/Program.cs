using Backend;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/payments", ([FromBody] PaymentIn input) =>
{
    // Salva num dicionario?

    return Results.Ok(new {});
});

app.MapGet("/payments-summary", ([AsParameters] PaymentSummaryIn input) =>
{
    return Results.Ok(new PaymentSummaryOut { Default = new(), Fallback = new() });
});

app.Run();

public partial class Program { }
