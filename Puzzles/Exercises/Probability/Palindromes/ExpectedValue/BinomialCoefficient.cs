using System;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public struct BinomialCoefficient
    {
        public BinomialCoefficient(int n, int k)
        {
            FailIfFirstNumberLessSecond(n, k);

            Value = CalculateBinomialCoefficient(n, k);
        }

        public long Value { get; }

        public static implicit operator long(BinomialCoefficient coefficient) => coefficient.Value;

        static long CalculateBinomialCoefficient(int n, int k)
        {
            long top = 1;

            for (var i = n; i >= n - k + 1; i--)
            {
                top *= i;
            }

            return top / new Factorial(k);
        }

        static void FailIfFirstNumberLessSecond(int n, int k)
        {
            if (n < k)
                throw new ArgumentException($"First number N [{n}] must be bigger second number K [{k}]");
        }
    }
}