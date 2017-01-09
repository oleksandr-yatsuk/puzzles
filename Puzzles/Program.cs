using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Puzzles.Common.Extensions;
using Puzzles.Exercises.Hackonacci;
using Puzzles.Exercises.Probability.Palindromes.ExpectedValue;
using Puzzles.Exercises.ZeroNim;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            /*var t = int.Parse(Console.ReadLine());
            var words = new string[t];

            for (var i = 0; i < t; i++)
            {
                words[i] = Console.ReadLine();
            }

            var alphabet = new Alphabet("abcd".ToCharArray());
            var resolver = new ExpectedValueResolver(alphabet);

            foreach (var word in words)
            {
                var swaps = resolver.GetExpectedNumberOfSwaps(word);

                Console.WriteLine(swaps.ToString("F4"));
            }*/

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var piles = new[]
            {
                new [] { 56, 72, 69, 26, 18, 25, 64, 77, 64, 105 },
                new [] { 45, 1, 42, 40, 52, 13, 28, 28, 55, 40 },
                new [] { 38, 76, 67, 30, 65, 45, 63, 36, 54, 33 },
                new [] { 61, 55, 53, 38, 73, 77, 53, 69, 12, 105 },
                new [] { 65, 13, 71, 25, 16, 3, 52, 43, 9, 33 },
                new [] { 4, 34, 14, 68, 78, 76, 55, 3, 60, 63 },
                new [] { 66, 12, 53, 10, 41, 25, 78, 52, 54, 13 },
                new [] { 16, 76, 39, 32, 30, 42, 26, 38, 57, 73 },
                new [] { 10, 72, 12, 7, 19, 18, 42, 30, 57, 48 },
                new [] { 21, 28, 57, 61, 53, 7, 64, 58, 21, 5 },
            };

            foreach (var pile in piles)
            {
                var game = new Game(pile);

                Console.WriteLine(game.IsCurrentPositionWinning ? "W" : "L");
            }

            //Console.WriteLine(stopWatch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
