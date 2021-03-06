﻿namespace Puzzles.Exercises.Arrays.MaximumSum
{
    public struct MaximumSubArraySum
    {
        readonly int[] _values;

        public MaximumSubArraySum(int[] values)
        {
            _values = values;
        }

        public MaximumSum Sum => CalculateMaxSubArraySum();

        MaximumSum CalculateMaxSubArraySum()
        {
            long sum = 0;
            var possibleStart = 0;

            var maxSum = long.MinValue;
            int start = 0, end = 0;

            for (var i = 0; i < _values.Length; i++)
            {
                sum += _values[i];

                if (sum > maxSum)
                {
                    maxSum = sum;

                    start = possibleStart;
                    end = i;
                }

                if (sum < 0)
                {
                    sum = 0;
                    possibleStart = i + 1;
                }
            }

            return new MaximumSum(start, end, maxSum);
        }
    }
}