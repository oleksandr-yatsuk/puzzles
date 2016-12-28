using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Hackonacci
{
    public class HackonacciMatrix
    {
        IDictionary<Angle, int> differences;

        public HackonacciMatrix(int dimension)
        {
            Dimension = dimension;
        }

        public int Dimension { get; set; }

        public int GetNumberOfDifferences(int angleDegrees)
        {
            return Differences[new Angle(angleDegrees)];
        }

        IDictionary<Angle, int> Differences => differences ?? (differences = CalculateDifferences(Dimension));
        
        static IDictionary<Angle, int> CalculateDifferences(int n)
        {
            var differences = new List<RotationDifference>(4)
            {
                new RotationDifference(new Angle(90)),
                new RotationDifference(new Angle(180))
            };

            for (var i = 1; i <= n; i++)
            {
                for (var j = i + 1; j <= n; j++)
                {
                    CalculateDifferenceForCell(i, j, n, differences);
                }
                CalculateDifferenceForDiagonalCell(i, n, differences);
            }

            AddDifferencesMissedAngles(differences);

            return EnumerableExtensions.ToDictionary(differences, difference => difference.Angle, difference => difference.Value);
        }

        static void AddDifferencesMissedAngles(ICollection<RotationDifference> differences)
        {
            var difference90 = differences.First(d => d.Angle.Degrees == 90);

            differences.Add(new RotationDifference(new Angle(0)));
            differences.Add(new RotationDifference(new Angle(270), difference90.Value));
        }

        static void CalculateDifferenceForDiagonalCell(int i, int n, IEnumerable<RotationDifference> differences)
        {
            var cell = new HackonacciCell(i, i);

            foreach (var difference in differences)
            {
                var rotatedCell = new HackonacciCell(new RotatedIndex(difference.Angle, i, i, n));

                difference.Add(cell.Symbol ^ rotatedCell.Symbol);
            }
        }

        static void CalculateDifferenceForCell(int i, int j, int n, IEnumerable<RotationDifference> differences)
        {
            var cell = new HackonacciCell(i, j);

            foreach (var difference in differences)
            {
                var rotatedCell = new HackonacciCell(new RotatedIndex(difference.Angle, cell.Row, cell.Column, n));
                var rotatedOppositeCell = new HackonacciCell(new RotatedIndex(difference.Angle, cell.Column, cell.Row, n));

                difference.Add((cell.Symbol ^ rotatedCell.Symbol) + (cell.Symbol ^ rotatedOppositeCell.Symbol));
            }
        }
    }
}