using System;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class Point : IEquatable<Point>
	{
		public readonly int X;
		public readonly int Y;
		public readonly int Z;

		public Point(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public int QuadraticDistanceTo(int x, int y, int z)
		{
			return (X - x)*(X - x) + (Y - y)*(Y - y) + (Z - z)*(Z - z);
		}
		
		public int QuadraticDistanceTo(Point point)
		{
			return (X - point.X) * (X - point.X)
				+ (Y - point.Y) * (Y - point.Y)
				+ (Z - point.Z) * (Z - point.Z);
		}

		public bool Equals(Point other)
		{
			return other.X == X &&
			       other.Y == Y &&
			       other.Z == Z;
		}
	}
}