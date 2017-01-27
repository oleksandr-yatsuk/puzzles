namespace Puzzles.Exercises.Arrays.MaximumSum
{
    public struct MaximumSum
    {
        public MaximumSum(int startIndex, int endIndex, long value)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
            Value = value;
        }

        public int StartIndex { get; }
        public int EndIndex { get; }
        public long Value { get; }
    }
}