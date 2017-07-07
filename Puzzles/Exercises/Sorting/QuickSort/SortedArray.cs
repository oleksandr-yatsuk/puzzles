using System;
using System.Collections.Generic;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Sorting.QuickSort
{
    public class SortedArray
    {
        static readonly Random Random = new Random(DateTime.UtcNow.Millisecond ^ Guid.NewGuid().GetHashCode() ^ 111111117);
        readonly int[] _values;

        public SortedArray(int[] values)
        {
            _values = values;
        }

        public int[] RecursivelySorted
        {
            get
            {
                var copy = _values.Copy();

                RecursiveQuickSort(copy, 0, copy.Length - 1);

                return copy;
            }
        }

        public int[] Sorted => InlineQuickSort(_values.Copy());

        static int[] InlineQuickSort(int[] values)
        {
            var rangesToProcess = new Stack<Range>();

            rangesToProcess.Push(new Range(0, values.Length - 1, values));

            while (rangesToProcess.Count > 0)
            {
                var range = rangesToProcess.Pop();
                var partition = new Partition(range.Start, range.End, range.Array);

                rangesToProcess.Push(partition.Ranges);
            }

            return values;
        }

        static void RecursiveQuickSort(int[] values, int start, int end)
        {
            if (start < end)
            {
                var partition = RandomizedPartition(values, start, end);

                RecursiveQuickSort(values, start, partition - 1);
                RecursiveQuickSort(values, partition + 1, end);
            }
        }

        static int RandomizedPartition(int[] values, int start, int end)
        {
            var pivotIndex = Random.Next(start, end);

            values.Exchange(pivotIndex, end);

            return Partition(values, start, end);
        }

        static int Partition(int[] values, int start, int end)
        {
            var partition = start - 1;
            var pivot = values[end];

            for (var j = start; j < end; j++)
            {
                if (values[j] >= pivot)
                    values.Exchange(++partition, j);
            }

            values.Exchange(++partition, end);

            return partition;
        }
    }
}