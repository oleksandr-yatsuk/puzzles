using System;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public struct Factorial
    {
        public Factorial(int n)
        {
            FailIfNegative(n);

            Value = CalculateFactorial(n);
        }

        public long Value { get; }

        public static implicit operator long(Factorial factorial) => factorial.Value;

        static long CalculateFactorial(int n)
        {
            long factorial = 1;

            for (var i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static void FailIfNegative(int number)
        {
            if (number < 0)
                throw new ArgumentException($"Number [{number}] must be 0 or positive");
        }
    }
}