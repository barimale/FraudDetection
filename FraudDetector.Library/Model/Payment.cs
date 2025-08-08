namespace FraudDetector.Library.Model
{
    public record Payment
    {
        public float Amount { get; init; }
        public Currency Currency { get; init; }
        public DateTime Timestamp { get; init; }
    }
}
