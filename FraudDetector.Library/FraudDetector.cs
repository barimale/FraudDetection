using FraudDetector.Library.Exceptions;
using FraudDetector.Library.Model;

namespace FraudDetector.Library
{
    public class FraudDetector
    {
        private const float FraudThreshold = 5459.12f;
        private const int FraudAmountOfExceededPayments = 3;

        public bool IsFraud(IEnumerable<Payment> payments)
        {
            var sortedPayments = payments
                .OrderBy(p => p.Timestamp)
                .ToList();

            bool areEqual = sortedPayments.SequenceEqual(payments);
            if(!areEqual)
            {
                throw new FraudoneByOneInvalidException(@"Payments are not defined one by one according to timestamp value.");
            }

            var isTimeValid = sortedPayments.Last().Timestamp.Minute - sortedPayments.First().Timestamp.Minute <= 1;

            if(!isTimeValid)
            {
                throw new FraudTimeInvalidException(@"Payments are not within the same minute.");
            }

            var amountOfexceededPayments = payments
                .Where(p => p.Amount > FraudThreshold)
                .ToList();

            if(amountOfexceededPayments.Count >= FraudAmountOfExceededPayments)
            {
                return true;
            }

            return false;
        }
    }
}
