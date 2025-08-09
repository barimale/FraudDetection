namespace FraudDetector.Library.Exceptions
{
    public class FraudOneByOneInvalidException : Exception
    {
        public FraudOneByOneInvalidException(string message) : base(message)
        {
            //intentionally left blank
        }
        public FraudOneByOneInvalidException(string message, Exception innerException) : base(message, innerException)
        {
            //intentionally left blank
        }
    }
}
