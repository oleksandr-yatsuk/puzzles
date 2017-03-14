using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public class SequentialSumByModuleArray : IEnumerable<ArrayItem>
    {
        readonly long[] numbers;

        public SequentialSumByModuleArray(IReadOnlyList<long> numbers, long module)
        {
            Module = module;
            this.numbers = SumByModule(numbers, module);
        }

        public long this[int i] => numbers[i];
        public long Length => numbers.LongLength;
        public long Module { get; }


        static long[] SumByModule(IReadOnlyList<long> numbers, long module)
        {
            var summedNumbers = new long[numbers.Count];

            summedNumbers[0] = numbers[0];

            for (var i = 1; i < numbers.Count; i++)
            {
                summedNumbers[i] = (numbers[i] + summedNumbers[i - 1]) % module;
            }

            return summedNumbers;
        }

        public IEnumerator<ArrayItem> GetEnumerator()
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                yield return new ArrayItem(numbers[i], i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}