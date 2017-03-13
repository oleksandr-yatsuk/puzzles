namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MaxHeap
    {
        readonly Heap<int> _heap;

        public MaxHeap(Heap<int> heap)
        {
            _heap = heap;
        }

        public void MaxHeapify(int i)
        {
            var current = i;

            while (true)
            {
                var max = current;

                if (_heap.HasLeft(current) && _heap.Get(max) < _heap.GetLeft(current))
                    max = _heap.Left(current);

                if (_heap.HasRight(current) && _heap.Get(max) < _heap.GetRight(current))
                    max = _heap.GetRight(current);

                if (max == current) break;

                _heap.Exchange(current, max);

                current = max;
            }
        }
    }
}