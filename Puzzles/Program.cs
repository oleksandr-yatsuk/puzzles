using System;
using Puzzles.Common.Extensions;
using Puzzles.Exercises.Strings.PerfectSubsequences;
using Puzzles.Exercises.Trees.BinaryTrees;

namespace Puzzles
{
    class Program
    {
        public static void Main()
        {
            /*var game = new Game(new []{ "abcd", "cad", "dcc"}, 500000, 1000000007);

            foreach (var number in game.NumberOfPerfectSequences)
            {
                Console.WriteLine(number);
            }*/

            var root = new Node<int>(
                1,
                new Node<int>(2,
                              new Node<int>(4,
                                            new Node<int>(7,
                                                          null,
                                                          new Node<int>(13,
                                                                        new Node<int>(14), 
                                                                        new Node<int>(15,
                                                                                      null,
                                                                                      new Node<int>(16,
                                                                                                    new Node<int>(17), 
                                                                                                    new Node<int>(18))))), 
                                            null), 
                              new Node<int>(5, 
                                            new Node<int>(8), 
                                            null) 
                             ),
                new Node<int>(3,
                              new Node<int>(6,
                                            new Node<int>(9), 
                                            new Node<int>(10,
                                                          null,
                                                          new Node<int>(11,
                                                                        null,
                                                                        new Node<int>(12)))), 
                              null));

            var tree = new BinaryTree<int>(root);

            tree.TraverseInOrder().ForEach(n => Console.Write(n + " "));

            Console.WriteLine();

            tree.TraversePreOrder().ForEach(n => Console.Write(n + " "));

            Console.WriteLine();

            tree.TraversePostOrder().ForEach(n => Console.Write(n + " "));

            Console.ReadKey();
        }
    }
}
