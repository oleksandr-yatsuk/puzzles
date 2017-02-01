namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public struct MaximumSubArraySum
    {
        readonly int[] _numbers;
        readonly int _module;

        public MaximumSubArraySum(int[] numbers, int module)
        {
            _numbers = numbers;
            _module = module;
        }

        public int SubArraySum => CalculateMaxSubArraySum(_numbers, _module);

        static int CalculateMaxSubArraySum(int[] numbers, int module)
        {
            var sequentialArray = new SequentialSumByModuleArray(numbers, module);

            return MaxSubarraySum(sequentialArray);
        }

        static int MaxSubarraySum(SequentialSumByModuleArray sequentialArray)
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