namespace Fuzz.Util.Exceptions
{
    public class InvalidComparisonException : Exception
    {
        public InvalidComparisonException()
        {

        }

        public InvalidComparisonException(string message) : base(message)
        {

        }

        public InvalidComparisonException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}