using System.Globalization;

namespace Puzzles.Exercises.MatrixLayerRotation
{
    public struct MatrixCellCoordinates
    {
        public readonly int I;
        public readonly int J;

        public MatrixCellCoordinates(int i, int j)
        {
            I = i;
            J = j;
        }

        public override string ToString()
        {
            return $"[{I.ToString(CultureInfo.InvariantCulture)}, {J.ToString(CultureInfo.InvariantCulture)}]";
        }
    }
}