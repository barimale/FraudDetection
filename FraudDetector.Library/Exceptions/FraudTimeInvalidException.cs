namespace FraudDetector.Library.Exceptions
{
    public class FraudTimeInvalidException : Exception
    {
        public FraudTimeInvalidException(string message) : base(message)
        {
            //intentionally left blank
        }
        public FraudTimeInvalidException(string message, Exception innerException) : base(message, innerException)
        {
            //intentionally left blank
        }
    }
}
