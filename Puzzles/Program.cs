using System;
using Puzzles.Common.Extensions;
using Puzzles.Exercises.Strings.PerfectSubsequences;
using Puzzles.Exercises.Trees.BinaryTrees;
using Puzzles.Exercises.Trees.BinaryTrees.WithParents;

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

            var tree = new Exercises.Trees.BinaryTrees.BinaryTree<int>(root);

            tree.TraversePreOrder().ForEach(n => Console.Write(n + " "));

            Console.WriteLine();

            var root2 = new NodeWithParent<int>(
                1,
                new NodeWithParent<int>(2,
                    new NodeWithParent<int>(4,
                        new NodeWithParent<int>(7,
                            null,
                            new NodeWithParent<int>(13,
                                new NodeWithParent<int>(14),
                                new NodeWithParent<int>(15,
                                    null,
                                    new NodeWithParent<int>(16,
                                        new NodeWithParent<int>(17),
                                        new NodeWithParent<int>(18))))),
                        null),
                    new NodeWithParent<int>(5,
                        new NodeWithParent<int>(8),
                        null)
                ),
                new NodeWithParent<int>(3,
                    new NodeWithParent<int>(6,
                        new NodeWithParent<int>(9),
                        new NodeWithParent<int>(10,
                            null,
                            new NodeWithParent<int>(11,
                                null,
                                new NodeWithParent<int>(12)))),
                    null));

            var tree2 = new Exercises.Trees.BinaryTrees.WithParents.BinaryTree<int>(root2);

            //tree.TraverseInOrder().ForEach(n => Console.Write(n + " "));

            //Console.WriteLine();

            tree2.TraversePreOrder().ForEach(n => Console.Write(n + " "));

            //Console.WriteLine();

            //tree.TraversePostOrder().ForEach(n => Console.Write(n + " "));

            Console.ReadKey();
        }
    }
}
