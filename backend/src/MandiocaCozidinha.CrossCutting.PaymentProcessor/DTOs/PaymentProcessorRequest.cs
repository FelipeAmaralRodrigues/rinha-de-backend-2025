namespace MandiocaCozidinha.CrossCutting.PaymentProcessor.DTOs
{
    public record PaymentProcessorRequest
    {
        public Guid CorrelationId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
