using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class TestCaseReader
	{
		static readonly char[] CoordinatesSeparator = { ' ' };

		public IEnumerable<TestCase> ReadTestCases(string filePath)
		{
			var lines = File.ReadAllLines(filePath);

			if (TestCasesFileIsEmpty(lines))
			{
				return Enumerable.Empty<TestCase>();
			}

			var testCasesNumber = Convert.ToInt32(lines.First());
			var testCases = new List<TestCase>(testCasesNumber);

			var currentTestCaseNumber = 0;

			for (var i = 1; i < lines.Length; i++)
			{
				if (LineIsEmpty(lines[i]))
					continue;

				var numberOfBombs = Convert.ToInt32(lines[i]);
				var bombsLocations = new Point[numberOfBombs];

				for (var j = 0; j < numberOfBombs; j++)
				{
					bombsLocations[j] = LineToPoint(lines[++i]);
				}

				testCases.Add(TestCaseWith(bombsLocations, ++currentTestCaseNumber));
			}

			return testCases;
		}

		static Point LineToPoint(string line)
		{
			var coordinates = line.Split(CoordinatesSeparator, StringSplitOptions.RemoveEmptyEntries);

			return new Point(Convert.ToInt32(coordinates[0]), 
				Convert.ToInt32(coordinates[1]), 
				Convert.ToInt32(coordinates[2]));
		}

		static TestCase TestCaseWith(Point[] bombsLocations, int number)
		{
			return new TestCase(bombsLocations, number);
		}

		static bool LineIsEmpty(string line)
		{
			return string.IsNullOrWhiteSpace(line);
		}

		static bool TestCasesFileIsEmpty(IEnumerable<string> fileLines)
		{
			return fileLines == null ||
			       !fileLines.Any();
		}
	}
}