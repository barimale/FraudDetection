using FraudDetector.Library.Model;

namespace FraudDetector.Library.Model.Comparers
{
    public class PaymentSequenceComparer : IEqualityComparer<Payment>
    {
        public bool Equals(Payment x, Payment y)
        {
            return x.Amount == y.Amount && x.Timestamp == y.Timestamp && x.Currency == y.Currency;
        }

        public int GetHashCode(Payment obj) => HashCode.Combine(obj.Amount, obj.Timestamp, obj.Currency);
    }

}