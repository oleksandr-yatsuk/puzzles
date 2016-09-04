using System.Globalization;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class TestCaseWriter
	{
		readonly FileWriter fileWriter;
		
		static readonly string CoordinatesSeparator = " ";

		public TestCaseWriter(FileWriter fileWriter)
		{
			this.fileWriter = fileWriter;
		}

		public void WriteTestCases(TestCase[] testCases)
		{
			WriteNumberOfTestCases(testCases.Length);
			
			for (var t = 0; t < testCases.Length; t++)
			{
				WriteTestCase(testCases[t]);
			}
		}

		void WriteTestCase(TestCase testCase)
		{
			fileWriter.AppendLine(testCase.BombsLocations.Length.ToString(CultureInfo.InvariantCulture));

			for (var b = 0; b < testCase.BombsLocations.Length; b++)
			{
				fileWriter.AppendLine(BombToString(testCase.BombsLocations[b]));
			}
		}

		static string BombToString(Point bomb)
		{
			return string.Format("{1}{0}{2}{0}{3}", CoordinatesSeparator,
				bomb.X.ToString(CultureInfo.InvariantCulture),
				bomb.Y.ToString(CultureInfo.InvariantCulture),
				bomb.Z.ToString(CultureInfo.InvariantCulture));
		}

		void WriteNumberOfTestCases(int length)
		{
			fileWriter.AppendLine(length.ToString(CultureInfo.InvariantCulture));
		}
	}
}