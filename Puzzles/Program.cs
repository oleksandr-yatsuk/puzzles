using System;
using Puzzles.Exercises.Arrays.MaximumSum;
using Puzzles.Exercises.Sorting.HeapSort;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            var n1 = new[]
            {
                1, 3, 5, 7
            };

            var n2 = new[]
            {
                0, 2, 4, 6
            };

            var n3 = new[]
            {
                -1
            };

            var merged = new MergedSortedArray(n1, n3, n2);

            var mergedArray = string.Join(", ", merged.MergedArray);

            Console.WriteLine(mergedArray);
            Console.ReadKey();
        }
    }
}
