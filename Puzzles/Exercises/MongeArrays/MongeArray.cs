using System;
using System.Collections.Generic;

namespace Puzzles.Exercises.MongeArrays
{
	public class MongeArray
	{
		readonly int[][] array;

		public MongeArray(int rows, int columns)
		{
			array = new int[rows][];
			for (var i = 0; i < rows; i++)
			{
				array[i] = new int[columns];
			}
		}

		public MongeArray(int[][] array)
		{
			if(array == null)
				throw new ArgumentNullException(nameof(array));

			this.array = array;
		}

		public int[] GetRow(int i)
		{
			return array[i];
		}

		public int Get(int i, int j)
		{
			return array[i][j];
		}

		public void Set(int i, int j, int value)
		{
			array[i][j] = value;
		}

		public int Rows => array?.Length ?? 0;
		public int Columns => (array?.Length ?? 0) == 0 ? 0 : (array[0]?.Length ?? 0);

		public MongeArray EvenRows => GetEvenRowsArray(this);
		public MongeArray OddRows => GetOddRowsArray(this);

		static MongeArray GetEvenRowsArray(MongeArray mongeArray)
		{
			var rows = mongeArray.Rows >> 1;
			var array = new List<int[]>(rows);

			for (var i = 1; i < mongeArray.Rows; i+=2)
			{
				array.Add(mongeArray.GetRow(i));
			}

			return new MongeArray(array.ToArray());
		}

		static MongeArray GetOddRowsArray(MongeArray mongeArray)
		{
			var rows = (mongeArray.Rows >> 1) + (mongeArray.Rows & 1);
			var array = new List<int[]>(rows);

			for (var i = 0; i < mongeArray.Rows; i += 2)
			{
				array.Add(mongeArray.GetRow(i));
			}

			return new MongeArray(array.ToArray());
		}
	}
}