namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class Cube
	{
		public readonly Point V1;
		public readonly Point V8;

		public Cube(Point start, Point end)
		{
			V1 = new Point(start.X, start.Y, start.Z);
			V8 = new Point(end.X, end.Y, end.Z);
		}

		public Point[] Vertexes
		{
			get
			{
				return new[]
				{
					// Bottom plane
					V1,
					new Point(V1.X, V8.Y, V1.Z),
					new Point(V8.X, V8.Y, V1.Z),
					new Point(V8.X, V1.Y, V1.Z),

					// Top plane
					new Point(V8.X, V1.Y, V8.Z),
					new Point(V1.X, V1.Y, V8.Z),
					new Point(V1.X, V8.Y, V8.Z),
					V8
				};
			}
		}

		public Cube[] SplittedByMiddle
		{
			get
			{
				var middle = GetMiddlePoint(V1, V8);

				return new[]
				{
					// Bottom cubes
					new Cube(V1, middle),
					new Cube(new Point(V1.X, middle.Y+1, V1.Z), new Point(middle.X, V8.Y, middle.Z)),
					new Cube(new Point(middle.X+1, middle.Y+1, V1.Z), new Point(V8.X, V8.Y, middle.Z)),
					new Cube(new Point(middle.X+1, V1.Y, V1.Z), new Point(V8.X, middle.Y, middle.Z)),
					
					// Top cubes
					new Cube(new Point(middle.X+1, V1.Y, middle.Z+1), new Point(V8.X, middle.Y, V8.Z)),
					new Cube(new Point(V1.X, V1.Y, middle.Z+1), new Point(middle.X, middle.Y, V8.Z)),
					new Cube(new Point(V1.X, middle.Y+1, middle.Z+1), new Point(middle.X, V8.Y, V8.Z)),
					new Cube(new Point(middle.X+1, middle.Y+1, middle.Z+1), new Point(V8.X, V8.Y, V8.Z))
				};
			}
		}

		public bool ConsistsOfOnePoint
		{
			get { return V1.Equals(V8); }
		}

		public bool IsNotCorrect
		{
			get
			{
				return V1.X > V8.X ||
					   V1.Y > V8.Y ||
					   V1.Z > V8.Z;
			}
		}

		static Point GetMiddlePoint(Point start, Point end)
		{
			var x = (start.X + end.X) >> 1;
			var y = (start.Y + end.Y) >> 1;
			var z = (start.Z + end.Z) >> 1;

			return new Point(x, y, z);
		}
	}
}