namespace Puzzles.Exercises.Knapsack
{
    public struct Item
    {
        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }

        public int Value { get; }
        public int Weight { get; }
    }
}