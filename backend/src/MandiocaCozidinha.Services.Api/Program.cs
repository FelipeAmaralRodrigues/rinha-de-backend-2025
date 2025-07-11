using MandiocaCozidinha.Services.Api.Configurations;
using MandiocaCozidinha.CrossCutting.PaymentProcessor.Services;
using MandiocaCozidinha.CrossCutting.PaymentProcessor.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenConfig();
builder.Services.AddProcessorPaymentServices(builder.Configuration);

var app = builder.Build();
app.UseOpenApiWithScalarConfig();
app.UseHttpsRedirection();

app.MapPost("/payments", async (PaymentRequest request, IPaymentProcessorService processorPaymentService) =>
{
    await processorPaymentService.SendPaymentAsync(new PaymentProcessorRequest
    {
        CorrelationId = request.CorrelationId,
        Amount = request.Amount,
        RequestedAt = DateTime.UtcNow
    });
    return Results.Created($"/payments/{request.CorrelationId}", request);
});

app.MapGet("/payments-summary", ([AsParameters]PaymentSummaryRequest request) =>
{
    return Results.Ok(new PaymentSummaryResponse
    {
        Default = new PaymentSummaryTypeProcessorResponse
        {
            TotalRequests = 43236,
            TotalAmount = 415542345.98M
        },
        Fallback = new PaymentSummaryTypeProcessorResponse
        {
            TotalRequests = 423545,
            TotalAmount = 329347.34M
        },
    });
});

app.Run();

public record PaymentRequest
{
    public Guid CorrelationId { get; set; }
    public decimal Amount { get; set; }
}

internal record PaymentSummaryRequest
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
internal record PaymentSummaryResponse
{
    public PaymentSummaryTypeProcessorResponse Default { get; set; }
    public PaymentSummaryTypeProcessorResponse Fallback { get; set; }
}

internal record PaymentSummaryTypeProcessorResponse
{
    public int TotalRequests { get; set; }
    public decimal TotalAmount { get; set; }
}