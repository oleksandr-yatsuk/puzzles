using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Arrays.DublicatesInArray
{
    public class ArrayWithDublicates
    {
        static readonly int[] Empty = Enumerable.Empty<int>().ToArray();

        public int[] RemoveDublicates(int[] sortedArray)
        {
            if (sortedArray == null || sortedArray.Length == 0)
            {
                return Empty;
            }

            return RemoveDublicatesWithYield(sortedArray).ToArray();
        }

        static IEnumerable<int> RemoveDublicatesWithYield(int[] sortedNumbers)
        {
            var previous = sortedNumbers[0];

            yield return previous;

            for (var i = 1; i < sortedNumbers.Length; i++)
            {
                if (sortedNumbers[i] != previous)
                    yield return sortedNumbers[i];

                previous = sortedNumbers[i];
            }
        }
    }
}