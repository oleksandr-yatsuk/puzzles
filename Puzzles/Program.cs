using System;
using Puzzles.Exercises.FlattenArray;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            var array = new object[]
            {
                1, 2, 3, new object [] { 4, 5, new  [] { 6, 7, 8 }, 9}, 10, 11, new [] {12, 13}
            };

            //var falttenedArray = new RecoursivelyFlattenedArray(array);
            var falttenedArray = new StackedFlattenedArray(array);
            //var falttenedArray = new ListFlattenedArray(array);
            var items = falttenedArray.Flatten<int>();

            Console.WriteLine(string.Join(", ", items));

            Console.ReadKey();
        }
    }
}
