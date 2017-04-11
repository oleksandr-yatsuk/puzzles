using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Sorting.HeapSort
{
    public class MergedSortedArray : IEnumerable<int>
    {
        readonly int[][] sortedArrays;

        public MergedSortedArray(params int[][] sortedArrays)
        {
            this.sortedArrays = sortedArrays;
        }

        public int[] MergedArray => BuildMergedSortedArray().ToArray();

        public int TotalLength => sortedArrays.Sum(a => a.Length);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<int> GetEnumerator() => BuildMergedSortedArray().GetEnumerator();

        IEnumerable<int> BuildMergedSortedArray()
        {
            var priorityHeap = new MaxPriorityHeap<SortedArrayElement>();

            foreach (var array in sortedArrays)
            {
                var sortedArrayElement = new SortedArrayElement(array);
                var element = new HeapValue<SortedArrayElement>(sortedArrayElement.Pop, sortedArrayElement);

                priorityHeap.Insert(element);
            }

            do
            {
                var max = priorityHeap.ExtractMax();

                yield return max.Key;

                if (max.Value.HasElements)
                {
                    priorityHeap.Insert(new HeapValue<SortedArrayElement>(max.Value.Pop, max.Value));
                }
            }
            while (!priorityHeap.IsEmpty);
        }
    }
}