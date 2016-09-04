using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Exercises.AddingThisAddingThat
{
	public class Calculator
	{
		public byte[] Add(byte[] f, byte[] s)
		{
			var sum = new Stack<byte>(f.Length);
			var next = 0;

			for (var i = f.Length - 1; i >= 0; i--)
			{
				int currentSum = f[i] + s[i] + next;

				next = currentSum >> 8;
				sum.Push((byte) currentSum);
			}

			if (next != 0)
				sum.Push(1);

			return sum.ToArray();
		}

		public byte[] AddRecursive(byte[] f, byte[] s)
		{
			return AddRecursive(f, s, f.Length - 1, 0)
				.Reverse()
				.ToArray();
		}

		static IEnumerable<byte> AddRecursive(byte[] f, byte[] s, int i, int valueToAdd)
		{
			if (i >= 0)
			{
				var sum = f[i] + s[i] + valueToAdd;

				yield return (byte) sum;

				foreach (var b in AddRecursive(f, s, i - 1, sum >> 8))
				{
					yield return b;
				}
			}
			else
			{
				if (valueToAdd > 0)
					yield return 1;
			}
		}
	}
}
