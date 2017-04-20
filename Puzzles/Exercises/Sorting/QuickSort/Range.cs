namespace Puzzles.Exercises.Sorting.QuickSort
{
    public struct Range
    {
        public Range(int start, int end, int[] array)
        {
            Start = start;
            End = end;
            Array = array;
        }

        public int Start { get; }
        public int End { get; }
        public int[] Array { get; }

        public bool IsValid => Start <= End;
    }
}