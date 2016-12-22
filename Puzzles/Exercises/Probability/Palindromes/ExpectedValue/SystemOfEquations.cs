using System;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public class SystemOfEquations
    {
        readonly Matrix<double> equationMatrix;
        SimpleGaussianElimination elimination = new SimpleGaussianElimination();

        public SystemOfEquations(Matrix<double> equationMatrix)
        {
            this.equationMatrix = equationMatrix;
        }

        public double[] SingleRoot => GaussianElimination();
        public RootsType RootsType => ResolveRootsType(equationMatrix);

        double[] GaussianElimination()
        {
            if (ResolveRootsType(equationMatrix) != RootsType.Single)
                throw new InvalidOperationException(@"Gaussian elimination is supported for single rooted equations now");

            return elimination.Resolve(equationMatrix);
        }

        static RootsType ResolveRootsType(Matrix<double> equations)
        {
            if (equations.Columns == equations.Rows + 1)
                return RootsType.Single;

            if (equations.Columns > equations.Rows + 1)
                return RootsType.Many;

            if (equations.Columns < equations.Rows + 1)
                return RootsType.NoOne;

            return RootsType.Unknown;
        }
    }
}