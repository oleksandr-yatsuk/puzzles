namespace Puzzles.Exercises.MatrixLayerRotation
{
    public class MatrixLayerArray
    {
        readonly Matrix _matrix;
        readonly int _diagonalCell;

        public MatrixLayerArray(Matrix matrix, int diagonalCell)
        {
            _matrix = matrix;
            _diagonalCell = diagonalCell;
        }

        public int Length => GetLength(_matrix, _diagonalCell);

        public int this[int i]
        {
            get
            {
                var cell = IndexToMatrixCell(_matrix, _diagonalCell, i);

                return _matrix[cell.I, cell.J];
            }
            set
            {
                var cell = IndexToMatrixCell(_matrix, _diagonalCell, i);

                _matrix[cell.I, cell.J] = value;
            }
        }

        static MatrixCellCoordinates IndexToMatrixCell(Matrix matrix, int diagonalCell, int i)
        {
            var rowsDimension = GetDimentionOfSubmatrix(matrix.RowsCount, diagonalCell);
            var columnsDimension = GetDimentionOfSubmatrix(matrix.ColumnsCount, diagonalCell);

            var index = new MatrixLayerArrayIndex(rowsDimension, columnsDimension, diagonalCell);

            return index.ToCell(i);
        }

        static int GetDimentionOfSubmatrix(int dimension, int diagonal)
        {
            return dimension - (diagonal << 1);
        }

        static int GetLength(Matrix matrix, int diagonal)
        {
            var heightInRows = GetDimentionOfSubmatrix(matrix.RowsCount, diagonal);
            var widthInColumns = GetDimentionOfSubmatrix(matrix.ColumnsCount, diagonal);

            if (heightInRows == 1)
                return widthInColumns;

            if (widthInColumns == 1)
                return heightInRows;

            return (heightInRows << 1) + (widthInColumns << 1) - 4;
        }
    }
}