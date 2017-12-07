using System;
using System.Linq;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class Matrix<T>
    {
        readonly T[][] _matrix;

        public Matrix(int rows, int columns, T defaultValue) : this(InitMatrix(rows, columns, defaultValue))
        { }

        public Matrix(int rows, int columns) : this(rows, columns, default(T))
        { }

        public Matrix(T[][] matrix)
        {
            _matrix = matrix;

            Rows = matrix.Length;
            Columns = matrix[0]?.Length ?? 0;
        }

        public int Rows { get; }
        public int Columns { get; }

        public bool IsEmpty => Rows < 1;

        public T this[int row, int column]
        {
            get => _matrix[row][column];
            set => _matrix[row][column] = value;
        }

        public T LastInRow(int row) => this[row, Columns - 1];

        public void SetLastInRow(T value, int row) => this[row, Columns - 1] = value;

        public T OnDiagonal(int row) => this[row, row];

        public void SetOnDiagonal(T value, int row) => this[row, row] = value;

        public Matrix<T> Copy()
        {
            var copy = new Matrix<T>(Rows, Columns);

            for (var i = 0; i < Rows; i++)
            for (var j = 0; j < Columns; j++)
                copy[i, j] = this[i, j];

            return copy;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _matrix.Select(row => string.Join(" ", row)));
        }

        static T[][] InitMatrix(int rows, int columns, T defaultValue)
        {
            var matrix = new T[rows][];

            for (var i = 0; i < rows; i++)
            {
                matrix[i] = new T[columns];

                for (var j = 0; j < columns; j++)
                {
                    matrix[i][j] = defaultValue;
                }
            }

            return matrix;
        }
    }
}