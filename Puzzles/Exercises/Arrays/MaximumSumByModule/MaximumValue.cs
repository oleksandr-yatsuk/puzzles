namespace Puzzles.Exercises.Arrays.MaximumSumByModule
{
    public class MaximumValue
    {
        public MaximumValue(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public void SetIfBigger(int value)
        {
            if (value > Value)
            {
                Value = value;
            }
        }

        public static implicit operator int(MaximumValue maximumValue) => maximumValue.Value;
    }
}