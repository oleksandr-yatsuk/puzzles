using System;

namespace Puzzles.Exercises.Strings.PerfectSubsequences
{
    public struct InverseFactorialsSet
    {
        readonly long[] inversedFactorials;

        public InverseFactorialsSet(long n, long primeModulus)
        {
            PrimeModulus = primeModulus;
            inversedFactorials = CalculateInverseFactorials(n, primeModulus);
        }

        public InverseFactorialsSet(FactorialsSet factorials)
        {
            PrimeModulus = factorials.Modulus;
            inversedFactorials = CalculateInverseFactorials(factorials);
        }

        public long PrimeModulus { get; }

        public long Get(long n)
        {
            if (n < 0 || n >= inversedFactorials.Length)
                throw new ArgumentException($"Number [{n}] is out of range of pre-calculated factorials");

            return inversedFactorials[n];
        }

        static long[] CalculateInverseFactorials(long n, long modulus) => CalculateInverseFactorials(new FactorialsSet(n, modulus));

        static long[] CalculateInverseFactorials(FactorialsSet factorials)
        {
            var modulus = factorials.Modulus;
            var inversed = new long[factorials.Count];

            for (long i = 0; i < inversed.LongLength; i++)
            {
                var degree = new DegreeValue(factorials.Get(i), modulus - 2, modulus);

                inversed[i] = degree.Value;
            }

            return inversed;
        }
    }
}