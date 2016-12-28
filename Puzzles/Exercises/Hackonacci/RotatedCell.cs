using System;

namespace Puzzles.Exercises.Hackonacci
{
    public struct RotatedCell
    {
        public RotatedCell(Angle angle, int i, int j, int n)
        {
            var rowAndColumn = CalculateRowAndColumn(angle, i, j, n);

            Row = rowAndColumn.Item1;
            Column = rowAndColumn.Item2;
        }

        public int Row { get; }
        public int Column { get; }

        static Tuple<int, int> CalculateRowAndColumn(Angle angle, int i, int j, int n)
        {
            int row = i, column = j;

            for (var k = 0; k < angle.Rotations; k++)
            {
                var t = row;

                row = n - column + 1;
                column = t;
            }

            return new Tuple<int, int>(row, column);
        }
    }
}