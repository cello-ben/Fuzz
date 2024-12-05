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
            HashSet<string> parsedArgs = new();
            int i = 0;
            while (i < argv.Length)
            {
                string sanitized = argv[i].Replace("-", String.Empty).ToLower();
                switch (sanitized)
                {
                    case "fuzzfactor": //TODO replace with decorator?
                        if (argv.Length > i + 1)
                        {
                            float fuzzFactor;
                            bool parseSuccess = float.TryParse(argv[++i], out fuzzFactor);
                            if (!parseSuccess || fuzzFactor < 0 || fuzzFactor > 1)
                            {
                                throw new InvalidFlagException("Must pass in a float from 0 to 1 for fuzzfactor.");
                            }
                            Env.fuzzFactor = fuzzFactor;
                        }
                        break;
                    default:
                        throw new InvalidFlagException($"Invalid flag passed in: {argv[i]}");
                }
                i++;
            }
            return parsedArgs;
        }
    }
}