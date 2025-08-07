namespace FraudDetector.Library.Model
{
    public class Payment
    {
        public float Amount { get; set; }
        public Currency Currency { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public enum Currency
    {
        PLN,
        USD,
        EUR,
        GBP
    }
}
