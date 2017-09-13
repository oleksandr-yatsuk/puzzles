namespace Puzzles.Exercises.Trees.BinaryTrees.WithParents
{
    public class NodeWithParent<T>
    {
        public NodeWithParent(T data, NodeWithParent<T> left, NodeWithParent<T> right)
        {
            Data = data;

            Left = left;
            Right = right;

            if (Left != null)
                Left.Parent = this;

            if (Right != null)
                Right.Parent = this;
        }

        public NodeWithParent(T data) : this(data, null, null)
        {
            Data = data;
        }
        
        public NodeWithParent<T> Parent { get; private set; }
        public NodeWithParent<T> Left { get; }
        public NodeWithParent<T> Right { get; }

        public NodeWithParent<T> LeftMost
        {
            get
            {
                var current = this;

                while (current.Left != null)
                    current = current.Left;

                return current;
            }
        }

        public T Data { get; }

        public bool IsRoot => Parent == null;
        public bool IsLeaf => Left == null && Right == null;

        public bool IsLeftChild => !IsRoot && this == Parent.Left;
        public bool IsRightChild => !IsRoot && this == Parent.Right;

        public bool HasRightSibling => !IsRightChild && Parent.Right != null;
    }
}