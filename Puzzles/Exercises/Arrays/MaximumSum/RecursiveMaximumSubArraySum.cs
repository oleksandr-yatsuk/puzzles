using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.Arrays.MaximumSum
{
    public struct RecursiveMaximumSubArraySum
    {
        readonly int[] _values;

        public RecursiveMaximumSubArraySum(int[] values)
        {
            _values = values;
        }

        public MaximumSum Sum => CalculateMaxSubArraySum(_values, 0, _values.Length - 1);

        static MaximumSum CalculateMaxSubArraySum(IReadOnlyList<int> values, int start, int end)
        {
            if(start == end)
                return new MaximumSum(start, end, values[start]);

            var middle = (start + end) >> 1;

            var sums = new[]
            {
                CalculateMaxSubArraySum(values, start, middle),
                CalculateMaxSubArraySum(values, middle + 1, end),
                CalculateCrossingSum(values, start, middle, end)
            };
            var maximum = sums.Max(s => s.Value);

            return sums.First(s => s.Value == maximum);
        }

        static MaximumSum CalculateCrossingSum(IReadOnlyList<int> values, int start, int middle, int end)
        {
            var sum = 0;

            var left = 0;
            var leftSum = int.MinValue;

            for (var i = middle; i >= start; i--)
            {
                sum += values[i];

                if (sum > leftSum)
                {
                    left = i;
                    leftSum = sum;
                }
            }

            sum = 0;

            var right = 0;
            var rightSum = int.MinValue;

            for (var i = middle + 1; i <= end; i++)
            {
                sum += values[i];

                if (sum > rightSum)
                {
                    right = i;
                    rightSum = sum;
                }
            }

            return new MaximumSum(left, right, leftSum + rightSum);
        }
    }
}