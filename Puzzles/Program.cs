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
                7, 5, 3, 1
            };

            var n2 = new[]
            {
                6, 4, 2, 0, -10
            };

            var n3 = new[]
            {
                -1, -5
            };

            var merged = new MergedSortedArray(n1, n3, n2);

            var mergedArray = string.Join(", ", merged.MergedArray);

            Console.WriteLine(mergedArray);
            Console.ReadKey();
        }
    }
}
