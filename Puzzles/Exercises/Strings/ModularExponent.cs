using System.Security.AccessControl;

namespace Puzzles.Exercises.Strings
{
    public struct ModularExponent
    {
        public ModularExponent(long number, long degree, long module)
        {
            Value = CalculateValue(number, degree, module);
        }

        public long Value { get; }

        static long CalculateValue(long number, long degree, long module)
        {
            var degrees = new long[64];
            degrees[0] = number % module;

            long result = 1;

            for (var i = 1; i < 64; i++)
            {
                degrees[i] = degrees[i - 1] * degrees[i - 1] % module;

                var shift = (long) 1 << i;

                if ((degree & shift) != 0)
                {
                    result = result * degrees[i] % module;
                }
            }

            return result;
        }
    }
}