using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Sorting.InsertionSort
{
    public class SortedArray
    {
        readonly int[] _array;

        public SortedArray(int[] array)
        {
            _array = array;
        }

        public int[] DescendingNumbers => RunInsertionDescendSort(_array.Copy());

        public int[] Numbers => RunInsertionSort(_array.Copy(), 0, _array.Length - 1);

        public void SortInPlace(int start, int end)
        {
            RunInsertionSort(_array, start, end);
        }

        static int[] RunInsertionDescendSort(int[] array)
        {
            var length = array.Length;

            for (var i = length - 2; i >= 0; i--)
            {
                var key = array[i];
                var j = i + 1;
                
                while (j < length && array[j] > key)
                {
                    array[j - 1] = array[j];
                    j++;
                }

                array[j - 1] = key;
            }

            return array;
        }

        static int[] RunInsertionSort(int[] array, int start, int end)
        {
            for (var i = start + 1; i <= end; i++)
            {
                var j = i - 1;
                var key = array[i];

                while (j >= start && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }

            return array;
        }
    }
}