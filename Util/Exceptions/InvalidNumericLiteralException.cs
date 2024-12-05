namespace Fuzz.Util.Exceptions
{
    public class InvalidNumericLiteralException : Exception
    {
        public InvalidNumericLiteralException()
        {

        }

        public InvalidNumericLiteralException(string message) : base(message)
        {

        }

        public InvalidNumericLiteralException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
