namespace Puzzles.Exercises.RunUpTheStairs
{
	public class Runner
	{
		public int GetNumberOfStrides(int[] flights, int stairsPerStride)
		{
			var numberOfStrides = 0;

			for (var i = 0; i < flights.Length; i++)
			{
				var numberOfSteps = flights[i];

				while (numberOfSteps > 0)
				{
					numberOfStrides++;
					numberOfSteps -= stairsPerStride;
				}
			}

			var turnStrides = (flights.Length - 1) << 1;

			return numberOfStrides + turnStrides;
		}
	}
}