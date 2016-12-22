namespace Puzzles
{
    public struct Angle
    {
        public Angle(int degrees)
        {
            Degrees = degrees%360;
        }

        public int Degrees { get; }
        public bool IsRotationNeeded => Degrees != 0;
        public int Rotations => Degrees/90;
    }
}