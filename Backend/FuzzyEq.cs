using System.Data;
using Fuzz.Util.Exceptions;

namespace Fuzz.Backend
{
    public class FuzzyEq
    {
        public static bool IsAboutEqual<T, U>(T a,  U b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException();
            }
            if (typeof(T) != typeof(U))
            {
                throw new InvalidComparisonException("Compared types must be the same.");
            }
            #pragma warning disable CS8604 //We have already done a null check, so we shouldn't need the warning.
            if (typeof(T) == typeof(int))
            {
                Console.WriteLine("FuzzyEq int");
            }
            else if (typeof(T) == typeof(float))
            {
                Console.WriteLine("FuzzyEq float");
            }
            else if (typeof(T) == typeof(string))
            {
                
                return _string(a as string, b as string);
            }
            #pragma warning restore CS8604
            else
            {
                throw new InvalidComparisonException($"Type {typeof(T)} not implemented yet. Feel free to make a pull request! :)");
            }
            return false;
        }

        public static bool _string(string a, string b)
        {
            Console.WriteLine($"In _string with {a} and {b}");
            return false;
        }
    }
}