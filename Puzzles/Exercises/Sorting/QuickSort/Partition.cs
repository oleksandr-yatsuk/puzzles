using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Sorting.QuickSort
{
    public struct Partition
    {
        readonly int _start;
        readonly int _end;
        readonly int[] _values;

        public Partition(int start, int end, int[] values)
        {
            _start = start;
            _end = end;
            _values = values;
        }

        public Range[] Ranges => Rearrange().ToArray();

        IEnumerable<Range> Rearrange()
        {
            var partition = _start - 1;
            var pivot = _values[_end];

            for (var j = _start; j < _end; j++)
            {
                if (_values[j] >= pivot)
                    _values.Exchange(++partition, j);
            }

            _values.Exchange(++partition, _end);

            var first = new Range(_start, partition - 1, _values);

            if (first.IsValid)
                yield return first;

            var second = new Range(partition + 1, _end, _values);

            if (second.IsValid)
                yield return second;
        }
    }
}