namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public struct SimpleGaussianElimination
    {
        public double[] Resolve(Matrix<double> equationsMatrix)
        {
            ZeroCellsDown(equationsMatrix);
            ZeroCellsUp(equationsMatrix);

            return CalculateRoots(equationsMatrix);
        }

        static void ZeroCellsDown(Matrix<double> matrix)
        {
            for (var column = 0; column < matrix.Columns - 2; column++)
            for (var row = column + 1; row < matrix.Rows; row++)
            {
                ZeroElementsInRow(matrix, column, row);
            }
        }

        static void ZeroCellsUp(Matrix<double> matrix)
        {
            for (var column = matrix.Columns - 2; column > 0; column--)
            for (var row = column - 1; row >= 0; row--)
            {
                ZeroElementsInRow(matrix, column, row);
            }
        }

        static void ZeroElementsInRow(Matrix<double> matrix, int diagonal, int row)
        {
            var divider = matrix[row, diagonal];

            if (!IsZero(divider))
            {
                var coefficient = matrix[diagonal, diagonal] / divider;

                for (var column = 0; column < matrix.Columns; column++)
                {
                    matrix[row, column] = matrix[diagonal, column] - matrix[row, column] * coefficient;
                }
            }
        }

        static double[] CalculateRoots(Matrix<double> matrix)
        {
            var roots = new double[matrix.Rows];

            for (var row = 0; row < matrix.Rows; row++)
            {
                roots[row] = Rounded(matrix.LastInRow(row) / matrix.OnDiagonal(row));
            }

            return roots;
        }

        static double Rounded(double number)
        {
            return new RoundedNumber(number);
        }

        static bool IsZero(double number)
        {
            return new RoundedNumber(number).IsZero;
        }
    }
}