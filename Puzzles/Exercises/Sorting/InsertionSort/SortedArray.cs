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

        public int[] Numbers => RunInsertionSort(_array.Copy());

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

        static int[] RunInsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i - 1;
                var key = array[i];

                while (j >= 0 && array[j] > key)
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