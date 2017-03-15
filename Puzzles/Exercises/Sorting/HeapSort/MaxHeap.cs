namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MaxHeap
    {
        public MaxHeap(Heap<int> heap)
        {
            Heap = heap;
        }

        public Heap<int> Heap { get; }
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

                if (Heap.HasLeft(current) && Heap.Get(max) < Heap.GetLeft(current))
                    max = Heap.Left(current);

                if (Heap.HasRight(current) && Heap.Get(max) < Heap.GetRight(current))
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