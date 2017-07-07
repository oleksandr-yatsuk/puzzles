using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Sorting.MergeSort
{
    public class SortedArray
    {
        readonly int[] array;

        public SortedArray(int[] array)
        {
            this.array = array;
        }

        public int[] SortedTopDown => SortTopDown(array);

        static int[] SortTopDown(int[] array)
        {
            var original = array.Copy();
            var working = array.Copy();

            SortTopDownRecursively(original, working, 0, original.Length - 1);

            return original;
        }

        static void SortTopDownRecursively(int[] destination, int[] working, int start, int end)
        {
            if(start >= end) return;

            var middle = (end + start) >> 1;

            SortTopDownRecursively(working, destination, start, middle);
            SortTopDownRecursively(working, destination, middle + 1, end);

            MergeTwoSortedArrays(destination, working, start, middle, end);
        }

        static void MergeTwoSortedArrays(int[] destination, int[] sortedParts, int start, int middle, int end)
        {
            var i = start;
            var j = middle + 1;

            for (var k = start; k <= end; k++)
            {
                if (j > end || (i <= middle && sortedParts[i] <= sortedParts[j]))
                {
                    destination[k] = sortedParts[i];
                    i++;
                    continue;
                }

                if (i > middle || (j <= end && sortedParts[j] <= sortedParts[i]))
                {
                    destination[k] = sortedParts[j];
                    j++;
                }
            }
        }
    }
}