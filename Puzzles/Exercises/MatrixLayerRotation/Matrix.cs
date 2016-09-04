using System;
using System.Linq;

namespace Puzzles.Exercises.MatrixLayerRotation
{
    public class Matrix
    {
        readonly int[][] _cells;
        readonly MatrixLayerArrayShifter _shifter = new MatrixLayerArrayShifter();
        
        public Matrix(int[][] cells)
        {
            _cells = cells;
        }

        public int RowsCount => _cells.Length;
        public int ColumnsCount => _cells?[0].Length ?? 0;

        public int this[int i, int j]
        {
            get { return _cells[i][j]; }
            set { _cells[i][j] = value; }
        }

        public void RotateLayers(int numberOfRotations)
        {
            var min = Math.Min(RowsCount, ColumnsCount);
            var numberOfLayers = (min >> 1) + (min & 1);

            for (var i = 0; i < numberOfLayers; i++)
            {
                RotateLayer(i, numberOfRotations);
            }
        }

        public override string ToString()
        {
            var rows = _cells.Select(r => string.Join(" ", r));

            return string.Join(Environment.NewLine, rows);
        }

        void RotateLayer(int diagonal, int numberOfRotations)
        {
            var array = new MatrixLayerArray(this, diagonal);

            _shifter.ShiftAgainstClock(array, numberOfRotations);
        }
    }
}