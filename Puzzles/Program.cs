using System;
using System.Collections.Generic;
using System.Diagnostics;
using Puzzles.Common.Extensions;
using Puzzles.Exercises.Hackonacci;
using Puzzles.Exercises.Probability.Palindromes.ExpectedValue;

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

            var matrix = new HackonacciMatrix(2000);

            Console.WriteLine(matrix.GetNumberOfDifferences(90));
            Console.WriteLine(matrix.GetNumberOfDifferences(180));
            Console.WriteLine(matrix.GetNumberOfDifferences(270));

            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
