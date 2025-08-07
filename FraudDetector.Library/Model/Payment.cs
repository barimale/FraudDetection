namespace FraudDetector.Library.Model
{
    public record Payment
    {
        public float Amount { get; init; }
        public Currency Currency { get; init; }
        public DateTime Timestamp { get; init; }
    }

    public enum Currency
    {
        PLN = 0,
        USD,
        EUR,
        GBP
    }
}
