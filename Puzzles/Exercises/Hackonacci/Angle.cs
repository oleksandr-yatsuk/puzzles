namespace Puzzles
{
    public struct Angle
    {
        public Angle(int degrees)
        {
            Degrees = degrees % 360;
            Rotations = Degrees / 90;
        }

        public int Degrees { get; }
        public int Rotations { get; }

        public bool IsRotationNeeded => Degrees != 0;

        public override int GetHashCode()
        {
            return Degrees;
        }

        public override bool Equals(object obj)
        {
            return obj != null && ((Angle) obj).Degrees == Degrees;
        }
    }
}