using System.Linq;

namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public struct MaximumSubArraySum
    {
        readonly long[] numbers;
        readonly long module;

        public MaximumSubArraySum(long[] numbers, long module)
        {
            this.numbers = numbers;
            this.module = module;
        }

        public long SubArraySum => CalculateMaxSubArraySum(numbers, module);

        static long CalculateMaxSubArraySum(long[] numbers, long module)
        {
            var sequentialArray = new SequentialSumByModuleArray(numbers, module);

            return MaxSubarraySum(sequentialArray);
        }

        static long MaxSubarraySum(SequentialSumByModuleArray sequentialArray)
        {
            var orderedArray = sequentialArray.OrderBy(n => n.Value).ToArray();
            var max = new MaximumValue();

            for (var i = 0; i < orderedArray.Length - 1; i++)
            {
                var current = orderedArray[i];
                var bigger = orderedArray[i + 1];

                if (bigger.LocatedBefore(current))
                {
                    max.SetIfBigger(current.Value - bigger.Value + sequentialArray.Module);
                }

                max.SetIfBigger(current.Value);
            }

            max.SetIfBigger(orderedArray.Last().Value);

            return max;
        }

        static long MaxSubarraySumBruteForce(SequentialSumByModuleArray sequentialArray)
        {
            var max = new MaximumValue(0);

            for (var i = 0; i < sequentialArray.Length; i++)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    max.SetIfBigger((sequentialArray[i] - sequentialArray[j] + sequentialArray.Module) % sequentialArray.Module);
                }

                max.SetIfBigger(sequentialArray[i]);
            }

            return max;
        }
    }
}