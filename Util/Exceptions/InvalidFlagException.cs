namespace Fuzz.Util.Exceptions
{
    public class InvalidFlagException : Exception
    {
        public InvalidFlagException()
        {

        }

        public InvalidFlagException(string message) : base(message)
        {

        }
        
        public InvalidFlagException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}