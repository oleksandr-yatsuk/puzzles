using System;

namespace Puzzles.Exercises.Strings.PerfectSubsequences
{
    public struct FactorialsSet
    {
        readonly long[] factorials;

        public FactorialsSet(long n, long modulus)
        {
            Modulus = modulus;
            factorials = CalculateFactorials(n, modulus);
        }

        public long Get(long n)
        {
            if(n < 0 || n >= factorials.Length)
                throw new ArgumentException($"Number [{n}] is out of range of pre-calculated factorials");

            return factorials[n];
        }

        public long Modulus { get; }
        public long Count => factorials.Length > 1 ? factorials.LongLength - 1 : 0;

        static long[] CalculateFactorials(long n, long modulus)
        {
            var factorials = new long[n + 1];

            factorials[0] = 1;

            for (long i = 1; i < n; i++)
            {
                factorials[i] = ((i % modulus) * factorials[i - 1]) % modulus;
            }

            return factorials;
        }
    }
}