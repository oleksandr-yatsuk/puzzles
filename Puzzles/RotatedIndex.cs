namespace Puzzles
{
    public struct RotatedIndex
    {
        public RotatedIndex(int i, int j, int n)
        {
            I = j;
            J = n - i + 1;
        }

        public RotatedIndex(RotatedIndex index, int n) : this(index.I, index.J, n)
        { }

        public int I { get; }
        public int J { get; }
    }
}