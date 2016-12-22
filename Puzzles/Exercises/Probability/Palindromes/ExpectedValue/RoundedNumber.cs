using System;

namespace Puzzles.Exercises.Probability.Palindromes.ExpectedValue
{
    public struct RoundedNumber
    {
        readonly int precision;

        public RoundedNumber(double originalNumber) : this(originalNumber, 4)
        { }

        public RoundedNumber(double originalNumber, int precision)
        {
            OriginalValue = originalNumber;
            this.precision = precision;
        }

        public double OriginalValue { get; }
        public double RoundedValue => Math.Round(OriginalValue, precision);

        public bool IsZero => Math.Abs(OriginalValue) < (1.0 / (10 ^ precision));
        public bool IsPositive => RoundedValue >= 0;

        public static implicit operator double (RoundedNumber number) => number.RoundedValue;
    }
}