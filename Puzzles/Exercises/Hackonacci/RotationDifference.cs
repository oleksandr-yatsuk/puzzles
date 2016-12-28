namespace Puzzles.Exercises.Hackonacci
{
    public class RotationDifference
    {
        public RotationDifference(Angle angle) : this(angle, 0)
        { }

        public RotationDifference(Angle angle, int initialValue)
        {
            Angle = angle;
            Value = initialValue;
        }

        public Angle Angle { get; }
        public int Value { get; private set; }

        public void Add(int value)
        {
            this.Value += value;
        }
    }
}