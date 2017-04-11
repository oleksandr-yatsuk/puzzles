namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MaxHeapGeneric<T>
    {
        public MaxHeapGeneric(Heap<HeapValue<T>> heap)
        {
            Heap = heap;
        }

        public Heap<HeapValue<T>> Heap { get; }
        public int HeapSize => Heap.Size;

        public void BuildMaxHeap()
        {
            for (var i = Heap.LeafsIndex; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public void MaxHeapify(int i)
        {
            var current = i;

            while (true)
            {
                var max = current;

                if (Heap.HasLeft(current) && Heap.Get(max).Key < Heap.GetLeft(current).Key)
                    max = Heap.Left(current);

                if (Heap.HasRight(current) && Heap.Get(max).Key < Heap.GetRight(current).Key)
                    max = Heap.Right(current);

                if (max == current) break;

                Heap.Exchange(current, max);
                current = max;
            }
        }

        public void Sort()
        {
            for (var size = Heap.Size; size > 1; size--)
            {
                BuildMaxHeap();

                Heap.Exchange(0, size - 1);
                Heap.OverwriteSize(size - 1);
            }

            Heap.ResetSize();
        }
    }
}