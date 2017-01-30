using System;
using Puzzles.Exercises.Arrays.MaximumSum;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            var numbers = new[]
            {
                1, -2, 7, -5, -1, 7
            };


            Console.WriteLine(new MaximumSubArraySum(numbers).Sum.ToString());
            Console.WriteLine(new RecursiveMaximumSubArraySum(numbers).Sum.ToString());

            Console.ReadKey();
        }
    }
}
