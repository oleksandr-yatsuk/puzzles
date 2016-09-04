namespace Puzzles.Exercises.MatrixLayerRotation
{
    public struct MatrixLayerArrayIndex
    {
        readonly int _rowsDown;
        readonly int _columnsRight;
        readonly int _leftTopIndex;

        public MatrixLayerArrayIndex(int rowsDown, int columnsRight, int leftTopIndex)
        {
            _rowsDown = rowsDown;
            _columnsRight = columnsRight;
            _leftTopIndex = leftTopIndex;
        }

        public int BottomMostRowIndex => _leftTopIndex + _rowsDown - 1;
        public int RightMostColumnIndex => _leftTopIndex + _columnsRight - 1;

        public MatrixCellCoordinates ToCell(int index)
        {
            if (index < _rowsDown)
            {
                return new MatrixCellCoordinates(_leftTopIndex + index, _leftTopIndex);
            }

            if (index < _rowsDown + _columnsRight - 1) // Minus one mutual vertex
            {
                return new MatrixCellCoordinates(BottomMostRowIndex, index - _rowsDown + _leftTopIndex + 1);
            }

            if (index < 2 * _rowsDown + _columnsRight - 2) // Minus 2 mutual vertexes
            {
                return new MatrixCellCoordinates(_leftTopIndex + _rowsDown - 2 - (index - _rowsDown - (_columnsRight - 1)), RightMostColumnIndex);
            }

            return new MatrixCellCoordinates(_leftTopIndex, _leftTopIndex + _columnsRight - 2 - (index - (2 * _rowsDown + _columnsRight - 2)));
        }
    }
}