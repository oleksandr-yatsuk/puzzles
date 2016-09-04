using System;
using System.IO;

namespace Puzzles.Exercises.SafestPlaceInTheGalaxy
{
	public class FileWriter : IDisposable
	{
		StreamWriter writer;

		public FileWriter(string filePath)
		{
			writer = new StreamWriter(filePath, false);
		}

		public void AppendLine(string value)
		{
			writer.WriteLine(value);
			writer.Flush();
		}

		public void Dispose()
		{
			if (writer != null)
			{
				writer.Dispose();
				writer = null;
			}
		}

		public static FileWriter Writer(string filePath)
		{
			return new FileWriter(filePath);
		}
	}
}