using FraudDetector.Library.Model;

namespace FraudDetector.Library
{
    public interface IFraudDetector
    {
        bool IsFraud(IEnumerable<Payment> payments);
    }
}