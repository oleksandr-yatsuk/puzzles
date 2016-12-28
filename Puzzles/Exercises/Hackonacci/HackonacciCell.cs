using System.Collections.Generic;

namespace Puzzles.Exercises.Hackonacci
{
    public struct HackonacciCell
    {
        static readonly IDictionary<long, int> Values = new Dictionary<long, int>
        {
            {1, (int)new HackonacciNumber(1).Value & 1},
            {2, (int)new HackonacciNumber(2).Value & 1},
            {3, (int)new HackonacciNumber(3).Value & 1},
            {4, (int)new HackonacciNumber(4).Value & 1},
            {5, (int)new HackonacciNumber(5).Value & 1},
            {6, (int)new HackonacciNumber(6).Value & 1},
            {0, (int)new HackonacciNumber(7).Value & 1}
        };

        public HackonacciCell(int row, int column)
        {
            Row = row;
            Column = column;

            Symbol = Values[((long)(row * column) * (row * column)) % 7];
        }

        public HackonacciCell(RotatedCell cell) : this(cell.Row, cell.Column)
        { }

        public int Row { get; }
        public int Column { get; }

        public int Symbol { get; }
    }
}