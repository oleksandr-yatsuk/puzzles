namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MaxHeap
    {
        public MaxHeap(Heap<int> heap)
        {
            Heap = heap;
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
                    max = Heap.GetRight(current);

                if (max == current) break;

                Heap.Exchange(current, max);
                current = max;
            }
        }

        public Heap<int> Heap { get; }
    }
}