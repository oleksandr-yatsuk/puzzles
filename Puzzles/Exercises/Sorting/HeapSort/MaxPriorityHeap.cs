using System;

namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MaxPriorityHeap<T>
    {
        readonly Heap<HeapValue<T>> heap = new Heap<HeapValue<T>>();

        public void Insert(HeapValue<T> value)
        {
            var valueWithMinKey = value.WithNewKey(int.MinValue);

            heap.Append(valueWithMinKey);
            IncreaseKey(heap.LastIndex, value.Key);
        }

        public HeapValue<T> ExtractMax()
        {
            var max = Max;

            heap.Exchange(0, heap.LastIndex);
            heap.RemoveLast();

            MaxHeapify(0);

            return max;
        }

        public void IncreaseKey(int i, int newKey)
        {
            var current = heap.Get(i);

            FailIfNewKeyIsLess(current.Key, newKey);

            heap.Set(i, current.WithNewKey(newKey));

            while (!heap.IsRoot(i) && heap.GetParent(i).Key < newKey)
            {
                var parent = heap.Parent(i);

                heap.Exchange(i, parent);
                i = parent;
            }
        }

        public HeapValue<T> Max => heap.Get(0);
        public bool IsEmpty => heap.IsEmpty;

        void MaxHeapify(int i)
        {
            var current = i;

            while (true)
            {
                var max = current;

                if (heap.HasLeft(current) && heap.Get(max) < heap.GetLeft(current))
                    max = heap.Left(current);

                if (heap.HasRight(current) && heap.Get(max) < heap.GetRight(current))
                    max = heap.Right(current);

                if (max == current) break;

                heap.Exchange(current, max);
                current = max;
            }
        }

        static void FailIfNewKeyIsLess(int key, int newKey)
        {
            if (newKey < key)
                throw new ArgumentException($"New key [{newKey}] must be bigger then old one [{key}]");
        }
    }
}