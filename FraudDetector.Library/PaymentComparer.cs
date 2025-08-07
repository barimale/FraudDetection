using FraudDetector.Library.Model;

namespace FraudDetector.Library
{
    public class PaymentComparer : IEqualityComparer<Payment>
    {
        public bool Equals(Payment x, Payment y)
        {
            return x.Amount == y.Amount && x.Timestamp == y.Timestamp && x.Currency == y.Currency;
        }

        public int GetHashCode(Payment obj)
        {
            return obj.Amount.GetHashCode() ^ obj.Timestamp.GetHashCode() ^ obj.Currency.GetHashCode();
        }
    }

}