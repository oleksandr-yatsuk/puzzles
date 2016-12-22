using System;
using System.Collections.Generic;
using Puzzles.Common.Extensions;
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

            var n = 2000;
            var q = 3;

            var angles = new int[]
            {
                0, 90, 180, 270
            };

            var symbolsInCells = new Dictionary<HackonacciCell, char>();

            for (var i = 1; i <= n; i++)
            {
                for (var j = i; j <= n; j++)
                {
                    var cell = new HackonacciCell(i, j);

                    if(!symbolsInCells.ContainsKey(cell))
                        symbolsInCells.Add(cell, cell.Symbol);
                }
            }

            var differences = new Dictionary<int, long>();

            for (var a = 0; a < angles.Length; a++)
            {
                var angle = new Angle(angles[a]);
                var difference = 0;

                if (angle.IsRotationNeeded)
                {
                    for (var i = 1; i <= n; i++)
                    {
                        for (var j = 1; j <= n; j++)
                        {
                            var rotationIndex = new RotatedIndex(i, j, n);

                            for (var k = 1; k < angle.Rotations; k++)
                            {
                                rotationIndex = new RotatedIndex(rotationIndex, n);
                            }

                            var originalCell = new HackonacciCell(i, j);
                            var rotatedCell = new HackonacciCell(rotationIndex.I, rotationIndex.J);

                            if (symbolsInCells[originalCell] != symbolsInCells[rotatedCell])
                                difference++;
                        }
                    }
                }
                differences.AddIfNotExists(angles[a], difference);

                Console.WriteLine(angles[a]);
            }

            Console.ReadKey();
        }
    }
}
