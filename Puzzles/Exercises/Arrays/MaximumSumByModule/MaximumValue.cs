namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public class MaximumValue
    {
        public MaximumValue(long value)
        {
            Value = value;
        }

        public MaximumValue() : this(0)
        {
            
        }

        public long Value { get; private set; }

        public void SetIfBigger(long value)
        {
            if (value > Value)
            {
                Value = value;
            }
        }

        public static implicit operator long(MaximumValue maximumValue) => maximumValue.Value;
    }
}