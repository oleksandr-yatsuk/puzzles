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
                    if (current.IsLeftChildOfParent && current.HasRightSibling)
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
    }
}