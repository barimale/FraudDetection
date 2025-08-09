using FraudDetector.Library.Exceptions;
using FraudDetector.Library.Model;
using FraudDetector.Library.Model.Comparers;

namespace FraudDetector.Library
{
    public class FraudDetector : IFraudDetector
    {
        private const float FraudThreshold = 5459.12f;
        private const int FraudAmountOfExceededPayments = 3;
        private const int PaymentsTimeThresholdInMinutes = 1;

        public bool IsFraud(IEnumerable<Payment> payments)
        {
            var sortedPayments = payments
                .OrderBy(p => p.Timestamp)
                .ToList();

            bool areEqual = payments.SequenceEqual(sortedPayments, new PaymentSequenceComparer());
            if (!areEqual)
            {
                throw new FraudOneByOneInvalidException(@"Payments are not defined one by one according to timestamp value.");
            }

            var isTimeValid = (sortedPayments.Last().Timestamp - sortedPayments.First().Timestamp).Minutes <= PaymentsTimeThresholdInMinutes;

            if (!isTimeValid)
            {
                throw new FraudTimeInvalidException(@"Payments are not within the same minute.");
            }

            var amountOfexceededPayments = payments
                .Where(p => p.Amount > FraudThreshold)
                .ToList();

            if (amountOfexceededPayments.Count >= FraudAmountOfExceededPayments)
            {
                return true;
            }

            return false;
        }
    }
}
