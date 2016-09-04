using System.Collections.Generic;

namespace Puzzles.Exercises.Probability.LazySorting
{
    public class Logan
    {
        public double GetAwaitedMinutes(int[] numbers)
        {
            if (IsSorted(numbers))
                return 0;

            return (double)Factorial(numbers.Length) / NotUniqueNumbersFactorials(numbers);
        }

        static long NotUniqueNumbersFactorials(int[] numbers)
        {
            var hashSet = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (hashSet.ContainsKey(number))
                {
                    ++hashSet[number];
                }
                else
                {
                    hashSet.Add(number, 1);
                }
            }

            long result = 1;

            foreach (var numberCount in hashSet.Values)
            {
                result *= Factorial(numberCount);
            }

            return result;
        }

        static long Factorial(int n)
        {
            long result = 1;

            for (long i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        static bool IsSorted(int[] numbers)
        {
            for (var i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                    return false;
            }

            return true;
        }
    }
}