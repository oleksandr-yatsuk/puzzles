using System.Collections.Generic;

namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public struct SequentialSumByModuleArray
    {
        readonly int[] _numbers;

        public SequentialSumByModuleArray(IReadOnlyList<int> numbers, int module)
        {
            Module = module;
            _numbers = SumByModule(numbers, module);
        }

        public int this[int i] => _numbers[i];
        public int Length => _numbers.Length;
        public int Module { get; }


        static int[] SumByModule(IReadOnlyList<int> numbers, int module)
        {
            var sumarizedNumbers = new int[numbers.Count];
            var sum = 0;

            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];

                sumarizedNumbers[i] = sum % module;
            }

            return sumarizedNumbers;
        }
    }
}