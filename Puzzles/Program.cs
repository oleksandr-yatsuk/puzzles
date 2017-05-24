using System;
using Puzzles.Exercises.Strings.PerfectSubsequences;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            var game = new Game(new []{ "abcd", "cad", "dcc"}, 500000, 1000000007);

            foreach (var number in game.NumberOfPerfectSequences)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
