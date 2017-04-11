namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class SortedArrayElement
    {
        readonly int[] sortedArray;
        int i;

        public SortedArrayElement(int[] sortedArray)
        {
            this.sortedArray = sortedArray;
        }

        public int Pop => sortedArray[i++];
        public bool HasElements => i < sortedArray.Length;
    }
}