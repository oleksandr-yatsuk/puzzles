namespace Puzzles.Exercises.AddingThisAddingThat
{
	public class AddResult
	{
		public readonly byte[] F;
		public readonly byte[] S;
		public readonly byte[] Result;

		public AddResult(byte[] f, byte[] s, byte[] result)
		{
			F = f;
			S = s;
			Result = result;
		}

		public string GetF()
		{
			return string.Join(", ", F);
		}
		
		public string GetS()
		{
			return string.Join(", ", S);
		}
		
		public string GetResult()
		{
			return string.Join(", ", Result);
		}
	}
}