namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public struct ArrayItem
    {
        public ArrayItem(long value, int originalIndex)
        {
            Value = value;
            OriginalIndex = originalIndex;
        }

        public long Value { get; }
        public int OriginalIndex { get; }

        public bool LocatedBefore(ArrayItem item)
        {
            return OriginalIndex < item.OriginalIndex;
        }
    }
}