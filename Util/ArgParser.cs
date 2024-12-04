using Fuzz.Util.Exceptions;

namespace Fuzz.Util
{
    public class ArgParser
    {
        string[] argv;
        public ArgParser(string[] _argv)
        {
            argv = _argv;
        }

        public HashSet<string> ParseArgs()
        {
            HashSet<string> parsedArgs = new HashSet<string>();
            int i = 0;
            while (i < argv.Length)
            {
                string sanitized = argv[i].Replace("-", String.Empty).ToLower();
                switch (sanitized)
                {
                    case "fuzzfactor":
                        if (argv.Length > i + 1)
                        {
                            float fuzzFactor;
                            bool parseSuccess = float.TryParse(argv[++i], out fuzzFactor);
                            if (!parseSuccess || fuzzFactor < 0F || fuzzFactor > 1F)
                            {
                                throw new InvalidFlagException("Must pass in a float from 0 to 1 for fuzzfactor.");
                            }
                            Env.fuzzFactor = fuzzFactor;
                        }
                        break;
                    default:
                        throw new InvalidFlagException("Invalid flag(s) passed in.");
                }
                i++;
            }
            return parsedArgs;
        }
    }
}