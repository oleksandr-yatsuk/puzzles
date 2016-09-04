using System;
using System.Collections.Generic;

namespace Puzzles.Exercises.Shuffling
{
    public class Shuffle
    {
        public int[] FisherYatesShuffle(int[] numbers)
        {
            var random = new Random(DateTime.UtcNow.Millisecond);

            for (var i = numbers.Length - 1; i > 0; i--)
            {
                InterchangeNumbers(numbers, i, random.Next(i + 1));
            }

            return numbers;
        }

        static void InterchangeNumbers<T>(IList<T> values, int i, int j)
        {
            var temp = values[i];

            values[i] = values[j];
            values[j] = temp;
        }
    }
}