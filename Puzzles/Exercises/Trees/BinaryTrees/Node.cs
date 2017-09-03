namespace Puzzles.Exercises.Trees.BinaryTrees
{
    public class Node<T>
    {
        public Node(T data, Node<T> left, Node<T> right)
        {
            Left = left;
            Right = right;
            Data = data;
        }

        public Node(T data) : this(data, null, null)
        { }

        public Node<T> Left { get; }
        public Node<T> Right { get; }

        public T Data { get; }

        public Node<T> LeftMostChild
        {
            get
            {
                var leftMost = this;

                while (leftMost?.Left != null)
                    leftMost = leftMost.Left;

                return leftMost;
            }
        }

        public bool IsLeaf => Left == null && Right == null;
    }
}