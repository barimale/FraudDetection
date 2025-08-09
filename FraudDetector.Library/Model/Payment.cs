namespace FraudDetector.Library.Model
{
    public readonly record struct Payment
    {
        public float Amount { get; init; }
        public Currency Currency { get; init; }
        public DateTime Timestamp { get; init; }
    }
}
