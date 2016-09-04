namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class TestCase
	{
		public readonly Point[] BombsLocations;
		public readonly int Number;

		public TestCase(Point[] bombsLocations, int number)
		{
			BombsLocations = bombsLocations;
			Number = number;
		}
	}
}