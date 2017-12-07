namespace Puzzles.Exercises.Knapsack
{
    public struct Item
    {
        public Item(int value, int weigh)
        {
            Value = value;
            Weigh = weigh;
        }

        public int Value { get; }
        public int Weigh { get; }
    }
}