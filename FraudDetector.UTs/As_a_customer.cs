using FraudDetector.Library;
using FraudDetector.Library.Exceptions;
using FraudDetector.Library.Model;

namespace FraudDetector.UTs
{
    public class As_a_customer
    {
        [Fact]
        public void When_correct_payments_are_done()
        {
            //given
            var payments = new List<Payment>
            {
                new Payment { Amount = 6000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 3010, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 7000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 1000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) }
            };
            IFraudDetector fraudDetector = new Library.FraudDetector();

            //when
            var result = fraudDetector.IsFraud(payments);

            //then
            Assert.False(result, "Expected fraud detection to return false for the given payments.");
        }

        [Fact]
        public void When_payments_are_not_defined_in_one_minute()
        {
            //given
            var payments = new List<Payment>
            {
                new Payment { Amount = 6000, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 3010, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 7000, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 1000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-8) }
            };
            IFraudDetector fraudDetector = new Library.FraudDetector();

            //when
            //then
            Assert.Throws<FraudTimeInvalidException>(() => fraudDetector.IsFraud(payments));
        }

        [Fact]
        public void When_payments_are_not_defined_one_by_one()
        {
            //given
            var payments = new List<Payment>
            {
                new Payment { Amount = 6000, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-11) },
                new Payment { Amount = 3010, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-12) },
                new Payment { Amount = 7000, Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 1000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) }
            };
            IFraudDetector fraudDetector = new Library.FraudDetector();

            //when
            //then
            Assert.Throws<FraudoneByOneInvalidException>(() => fraudDetector.IsFraud(payments));
        }

        [Fact]
        public void When_incorrect_payments_are_done()
        {
            //given
            var payments = new List<Payment>
            {
                new Payment { Amount = 5459.15f,  Currency = Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 3010, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 6900, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) },
                new Payment { Amount = 10000, Currency =  Currency.PLN, Timestamp = DateTime.UtcNow.AddMinutes(-10) }
            };
            IFraudDetector fraudDetector = new Library.FraudDetector();

            //when
            var result = fraudDetector.IsFraud(payments);

            //then
            Assert.True(result, "Expected fraud detection to return true for the given payments.");
        }
    }
}