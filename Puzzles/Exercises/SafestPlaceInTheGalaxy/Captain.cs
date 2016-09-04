using System;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class Captain
	{
		public int FindDistanceToTheSafestPointBruteforce(Point[] bombs, Cube cube)
		{
			var maxDistance = 0;

			for (var x = cube.V1.X; x <= cube.V8.X; x++)
			for (var y = cube.V1.Y; y <= cube.V8.Y; y++)
			for (var z = cube.V1.Z; z <= cube.V8.Z; z++)
			{
				var minDistance = Int32.MaxValue;

				for (var b = 0; b < bombs.Length; b++)
				{
					var distance = bombs[b].QuadraticDistanceTo(x, y, z);

					if (distance < minDistance)
					{
						minDistance = distance;
					}
				}

				if (minDistance > maxDistance)
				{
					maxDistance = minDistance;
				}
			}

			return maxDistance;
		}

		public int FindDistanceToTheSafestPoint(Point[] bombs, Cube cube)
		{
			var safestPlace = new SafestPlace();

			FindDistanceToTheSafestPoint(bombs, cube, safestPlace);

			return safestPlace.Distance;
		}

		static void FindDistanceToTheSafestPoint(Point[] bombs, Cube cube, SafestPlace safestPlace)
		{
			if (cube.IsNotCorrect)
				return;

			if (cube.ConsistsOfOnePoint)
			{
				safestPlace.Distance = MinDistanceToBombs(bombs, cube.V1);
				return;
			}

			if (CubeShouldNotBeSplitted(bombs, cube, safestPlace))
				return;

			var splittedCubes = cube.SplittedByMiddle;

			for (var i = 0; i < splittedCubes.Length; i++)
			{
				FindDistanceToTheSafestPoint(bombs, splittedCubes[i], safestPlace);
			}
		}

		static bool CubeShouldNotBeSplitted(Point[] bombs, Cube cube, SafestPlace safestPlace)
		{
			var min = Int32.MaxValue;

			for (var i = 0; i < bombs.Length; i++)
			{
				var maxDistanceToCube = MaxDistanceToCube(bombs[i], cube);

				if (maxDistanceToCube < min)
				{
					min = maxDistanceToCube;
				}
			}
			
			return min < safestPlace.Distance;
		}

		static int MinDistanceToBombs(Point[] bombs, Point point)
		{
			var min = Int32.MaxValue;

			for (var i = 0; i < bombs.Length; i++)
			{
				var distance = bombs[i].QuadraticDistanceTo(point);

				if (distance < min)
				{
					min = distance;
				}
			}

			return min;
		}
		
		static int MaxDistanceToCube(Point point, Cube cube)
		{
			var vertexes = cube.Vertexes;
			var maxDistance = 0;

			for (var i = 0; i < vertexes.Length; i++)
			{
				var distance = vertexes[i].QuadraticDistanceTo(point);
				
				if (distance > maxDistance)
				{
					maxDistance = distance;
				}
			}

			return maxDistance;
		}

		private class SafestPlace
		{
			int distance;

			public int Distance
			{
				get { return distance; }
				set { SetDistance(value); }
			}

			void SetDistance(int value)
			{
				if (value > distance)
				{
					distance = value;
				}
			}
		}
	}
}