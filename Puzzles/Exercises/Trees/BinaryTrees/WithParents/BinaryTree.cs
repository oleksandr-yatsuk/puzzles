using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Trees.BinaryTrees.WithParents
{
    public class BinaryTree<T>
    {
        public BinaryTree(NodeWithParent<T> root)
        {
            Root = root;
        }

        public NodeWithParent<T> Root { get; }

        public T[] TraverseInOrder() => TraverseInOrder(Root).ToArray();

        public T[] TraversePreOrder() => TraversePreOrder(Root).ToArray();

        static IEnumerable<T> TraversePreOrder(NodeWithParent<T> root)
        {
            var current = root;

            while (current != null)
            {
                yield return current.Data;

                if (current.Left != null)
                {
                    current = current.Left;
                    continue;
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    continue;
                }

                while (current != null)
                {
                    if (current.IsLeftChild && current.HasRightSibling)
                    {
                        current = current.Parent.Right;
                    }
                    else
                    {
                        current = current.Parent;
                    }
                }
            }
        }

        static IEnumerable<T> TraverseInOrder(NodeWithParent<T> root)
        {
            var current = root.LeftMost;

            while (current != null)
            {
                yield return current.Data;

                if (current.IsLeaf && current.IsLeftChild)
                {
                    current = current.Parent;
                    continue;
                }

                if (current.Right != null)
                {
                    current = current.Right.LeftMost;
                    continue;
                }

                NodeWithParent<T> prev;

                do
                {
                    prev = current;
                    current = current.Parent;
                } while (current != null && current.Right == prev);
            }
        }
    }
}