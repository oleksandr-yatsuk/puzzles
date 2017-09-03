using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Trees.BinaryTrees
{
    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> Root { get; }

        public Node<T> LeftMost => Root?.LeftMostChild;

        public bool IsEmpty => Root == null;

        public T[] TraverseInOrder() => TraverseInOrderWithStack(Root).ToArray();

        public T[] TraverseInOrderByMorris()
        {
            return null;
        }

        public T[] TraversePreOrder() => TraversePreOrderWithStack(Root).ToArray();

        public T[] TraversePostOrder() => TraversePostOrderWithStack(Root).ToArray();

        static IEnumerable<T> TraversePostOrderRecursively(Node<T> root)
        {
            if (root == null)
                return Enumerable.Empty<T>();

            var leftTree = TraversePostOrderRecursively(root.Left);
            var rightTree = TraversePostOrderRecursively(root.Right);
            var rootTree = new[] { root.Data };

            return leftTree.Concat(rightTree).Concat(rootTree);
        }

        static IEnumerable<T> TraversePreOrderRecursively(Node<T> root)
        {
            if (root == null)
                return Enumerable.Empty<T>();

            var rootTree = new[] { root.Data };
            var leftTree = TraversePreOrderRecursively(root.Left);
            var rightTree = TraversePreOrderRecursively(root.Right);

            return rootTree.Concat(leftTree).Concat(rightTree);
        }

        static IEnumerable<T> TraverseInOrderRecursively(Node<T> root)
        {
            if (root == null)
                return Enumerable.Empty<T>();

            var leftTree = TraverseInOrderRecursively(root.Left);
            var rootTree = new[] { root.Data };
            var rightTree = TraverseInOrderRecursively(root.Right);

            return leftTree.Concat(rootTree).Concat(rightTree);
        }

        static IEnumerable<T> TraverseInOrderWithStack(Node<T> root)
        {
            var stack = new Stack<Node<T>>();
            var current = root;

            do
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                if (stack.Any())
                {
                    current = stack.Pop();

                    yield return current.Data;

                    current = current.Right;
                }
            } while (current != null || stack.Any());
        }

        static IEnumerable<T> TraversePostOrderWithStack(Node<T> root)
        {
            var stack = new Stack<Node<T>>();
            var current = root;

            do
            {
                while (current != null)
                {
                    stack.PushIfNotNull(current.Right);
                    stack.Push(current);

                    current = current.Left;
                }

                if (!stack.Any()) break;

                current = stack.Pop();

                if (stack.Any() && current.Right == stack.Peek())
                {
                    stack.Pop();

                    stack.Push(current);
                    current = current.Right;
                }
                else
                {
                    yield return current.Data;
                    current = null;
                }

            } while (stack.Any());
        }

        static IEnumerable<T> TraversePreOrderWithStack(Node<T> root)
        {
            var stack = new Stack<Node<T>>();
            stack.PushIfNotNull(root);

            while (stack.Any())
            {
                var current = stack.Pop();

                stack.PushIfNotNull(current.Right);
                stack.PushIfNotNull(current.Left);

                yield return current.Data;
            }
        }
    }
}