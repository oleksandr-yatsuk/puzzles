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
            long sum = 0;

            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];

                summedNumbers[i] = sum = sum % module;
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