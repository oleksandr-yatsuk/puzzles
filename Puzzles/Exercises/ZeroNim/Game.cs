using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.ZeroNim
{
    public class Game
    {
        readonly int[] piles;

        public Game(int[] piles)
        {
            this.piles = piles;
        }

        public bool IsCurrentPositionWinning => XorAll(piles.Select(n => new GrundyNumber(n).Value)) != 0;

        static int XorAll(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(0, (current, n) => current ^ n);
        }
    }
}