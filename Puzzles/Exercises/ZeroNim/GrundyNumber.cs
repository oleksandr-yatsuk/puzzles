using System;

namespace Puzzles.Exercises.ZeroNim
{
    public struct GrundyNumber
    {
        public GrundyNumber(int number)
        {
            FailIfNegative(number);

            Value = CalculateValue(number);
        }

        public int Value { get; }

        public static implicit operator int(GrundyNumber number) => number.Value;

        static int CalculateValue(int number)
        {
            if (number == 0) return 0;

            return IsEven(number)
                ? number - 1
                : number + 1;
        }

        static bool IsEven(int number)
        {
            return (number & 1) == 0;
        }

        static void FailIfNegative(int number)
        {
            if(number < 0)
                throw new ArgumentException(@"Number must be positive", nameof(number));
        }
    }
}