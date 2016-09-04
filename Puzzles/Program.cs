using System;
using Puzzles.Exercises.Probability.Palindrome;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            var t = int.Parse(Console.ReadLine());
            var words = new string[t];

            for (var i = 0; i < t; i++)
            {
                words[i] = Console.ReadLine();
            }

            var swapper = new Swapper();

            foreach (var word in words)
            {
                var swaps = swapper.GetExpectedNumberOfSwaps(word);
                var rounded = Math.Round(swaps, 4, MidpointRounding.AwayFromZero);

                Console.WriteLine(rounded.ToString("F4"));
            }


            Console.ReadKey();
        }
    }
}
