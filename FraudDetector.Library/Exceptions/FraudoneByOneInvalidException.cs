namespace FraudDetector.Library.Exceptions
{
    public class FraudoneByOneInvalidException : Exception
    {
        public FraudoneByOneInvalidException(string message) : base(message)
        {
            //intentionally left blank
        }
        public FraudoneByOneInvalidException(string message, Exception innerException) : base(message, innerException)
        {
            //intentionally left blank
        }
    }
}
