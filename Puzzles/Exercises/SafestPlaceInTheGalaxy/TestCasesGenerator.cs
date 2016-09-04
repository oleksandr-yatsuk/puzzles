using System;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class TestCasesGenerator
	{
		public TestCase[] GeneraTestCases(int numberOfTestCases, int maxNumberOfBombs, int dimension)
		{
			var testCases = new TestCase[numberOfTestCases];

			for (var t = 0; t < numberOfTestCases; t++)
			{
				testCases[t] = GeneraTestCase(t+1, maxNumberOfBombs, dimension);
			}

			return testCases;
		}

		static TestCase GeneraTestCase(int testCaseNumber, int maxNumberOfBombs, int dimension)
		{
			var random = GetRandom(testCaseNumber);
			var numberOfBombs = random.Next(1, maxNumberOfBombs);
			var bombs = new Point[numberOfBombs];
			
			for (var i = 0; i < numberOfBombs; i++)
			{
				bombs[i] = new Point(random.Next(0, dimension), random.Next(0, dimension), random.Next(0, dimension));
			}

			return new TestCase(bombs, testCaseNumber);
		}

		static Random GetRandom(int testCaseNumber)
		{
			var seed = DateTime.UtcNow.Millisecond ^ testCaseNumber ^ DateTime.UtcNow.Millisecond;

			return new Random(seed);
		}
	}
}