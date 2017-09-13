namespace Puzzles.Exercises.Strings.PerfectSubsequences
{
    public struct DegreeValue
    {
        public DegreeValue(long number, long degree, long modulus)
        {
            Value = CalculateValue(number, degree, modulus);
        }

        public long Value { get; }

        static long CalculateValue(long number, long degree, long modulus)
        {
            var current = number % modulus;
            long result = 1;

            for (var i = 0; i < 64; i++)
            {
                if ((degree & ((long)1 << i)) != 0)
                {
                    result = result * current % modulus;
                }

                current = current * current % modulus;
            }

            return result;
        }
    }
}