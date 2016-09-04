namespace Puzzles.Exercises.MatrixLayerRotation
{
    public class MatrixLayerArrayShifter
    {
        public void ShiftAgainstClock(MatrixLayerArray array, int shiftDistance)
        {
            var length = array.Length;
            var shift = shiftDistance % length;

            if (shift != 0)
            {
                Reverse(array, 0, length - 1);
                Reverse(array, 0, shift - 1);
                Reverse(array, shift, length - 1);
            }
        }

        static void Reverse(MatrixLayerArray array, int i, int j)
        {
            var length = j - i + 1;
            var mediana = length >> 1;

            for (var k = 0; k < mediana; k++)
            {
                Swap(array, i + k, j - k);
            }
        }

        static void Swap(MatrixLayerArray array, int i, int j)
        {
            var ai = array[i];

            array[i] = array[j];
            array[j] = ai;
        }
    }
}