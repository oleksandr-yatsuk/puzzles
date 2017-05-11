namespace Puzzles.Exercises.Shuffling
{
    public class Shifter
    {
        public void ShiftRight(int[] numbers, int shiftDistance)
        {
            var length = numbers.Length;
            var shift = shiftDistance % length;

            if (shift != 0)
            {
                Reverse(numbers, 0, length - 1);
                Reverse(numbers, 0, shift - 1);
                Reverse(numbers, shift, length - 1);
            }
        }

        public int[] ShiftRightBruteForce(int[] numbers, int shiftDistance)
        {
            var shift = shiftDistance % numbers.Length;
            var length = numbers.Length;

            var array = new int[length];

            for (var i = 0; i < length; i++)
            {
                array[(i + shift) % length] = numbers[i];
            }

            return array;
        }

        public void ShiftRightOnce(int[] numbers)
        {
            for (var i = numbers.Length-1; i > 0; i--)
            {
                Swap(numbers, i, i - 1);
            }
        }

        public void ShiftLeftOnce(int[] numbers)
        {
            for (var i = 0; i < numbers.Length - 1; i++)
            {
                Swap(numbers, i, i + 1);
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            var ai = array[i];

            array[i] = array[j];
            array[j] = ai;
        }

        static void Reverse(int[] numbers, int i, int j)
        {
            var length = j - i + 1;
            var mediana = length >> 1;

            for (var k = 0; k < mediana; k++)
            {
                Swap(numbers, i + k, j - k);
            }
        }
    }
}