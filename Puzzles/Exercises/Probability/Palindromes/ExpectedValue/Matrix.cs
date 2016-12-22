using System;
using System.Linq;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class Matrix<T>
    {
        readonly T[][] matrix;

        public Matrix(int rows, int columns) : this(InitMatrix(rows, columns))
        { }

        public Matrix(T[][] matrix)
        {
            this.matrix = matrix;

            Rows = matrix.Length;
            Columns = matrix[0]?.Length ?? 0;
        }

        public int Rows { get; }
        public int Columns { get; }

        public bool IsEmpty => Rows < 1;

        public T this[int row, int column]
        {
            get { return matrix[row][column]; }
            set { matrix[row][column] = value; }
        }

        public T LastInRow(int row)
        {
            return this[row, Columns - 1];
        }

        public void SetLastInRow(T value, int row)
        {
            this[row, Columns - 1] = value;
        }

        public T OnDiagonal(int row)
        {
            return this[row, row];
        }

        public void SetOnDiagonal(T value, int row)
        {
            this[row, row] = value;
        }

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
            return string.Join(Environment.NewLine, matrix.Select(row => string.Join(" ", row)));
        }

        static T[][] InitMatrix(int rows, int columns)
        {
            var matrix = new T[rows][];

            for (var i = 0; i < rows; i++)
            {
                matrix[i] = new T[columns];
            }

            return matrix;
        }
    }
}