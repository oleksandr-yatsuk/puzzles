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

        public T Data { get; }

        public bool IsRoot => Parent == null;

        public bool IsLeftChildOfParent => !IsRoot && this == Parent.Left;
        public bool IsRightChildOfParent => !IsRoot && this == Parent.Right;

        public bool HasRightSibling => !IsRoot && Parent.Right != null;
    }
}