using Fuzz.Util;

namespace Fuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ArgParser argParser = new ArgParser(args);
            argParser.ParseArgs();
            Console.WriteLine(Env.fuzzFactor);
        }
    }
}