namespace Fuzz.Test
{
    public class Test
    {
        public static void RunTests()
        {
            int errors = 0;
            errors += FuzzyEqTest.RunFuzzyEqTests();
        }
    }
}