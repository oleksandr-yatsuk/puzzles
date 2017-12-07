using System;
using System.Linq;
using Puzzles.Common.Extensions;
using Puzzles.Exercises.Probability.Palindromes.ExpectedValue;

namespace Puzzles.Exercises.Knapsack
{
    public class Backpack
    {
        public Backpack(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; }

        public Item[] GetMaximumValuableContent(Item[] allItems)
        {
            return GetMaxValuableItemsRecursively(allItems, Capacity, allItems.Length - 1);
        }

        public int GetMaximumValueRecursively(Item[] items)
        {
            var capacity = Capacity;
            var n = items.Length - 1;

            return GetMaximumValueRecursively(items, capacity, n);
        }

        public int GetMaximumValueBruteforce(Item[] items)
        {
            var n = items.Length;
            var indexes = new CompositeIndexes(1, n);

            var result = 0;

            foreach (var index in indexes)
            {
                var current = items.Where((item, i) => index[i] == 1).ToArray();
                var weight = current.Sum(item => item.Weigh);

                if (weight > Capacity) continue;

                var value = current.Sum(item => item.Value);

                if (value > result)
                    result = value;
            }

            return result;
        }

        static int GetMaximumValueRecursively(Item[] items, int capacity, int n)
        {
            if (capacity <= 0 || n < 0)
                return 0;

            var sameCapacityValue = GetMaximumValueRecursively(items, capacity, n - 1);
            var current = items[n];

            if (capacity < current.Weigh)
                return sameCapacityValue;

            var currentCapacityValue = GetMaximumValueRecursively(items, capacity - current.Weigh, n - 1) + current.Value;
            var value = Math.Max(sameCapacityValue, currentCapacityValue);

            return value;
        }

        static Item[] GetMaxValuableItemsRecursively(Item[] items, int capacity, int n)
        {
            if (capacity <= 0 || n < 0) return Enumerable.Empty<Item>().ToArray();

            var sameCapacityItems = GetMaxValuableItemsRecursively(items, capacity, n - 1);
            var current = items[n];

            if (capacity < current.Weigh) return sameCapacityItems;

            var currentCapacityItems = GetMaxValuableItemsRecursively(items, capacity - current.Weigh, n - 1);

            var sameCapacityValue = sameCapacityItems.Sum(item => item.Value);
            var currentCapacityValue = currentCapacityItems.Sum(item => item.Value) + current.Value;

            return currentCapacityValue > sameCapacityValue 
                ? currentCapacityItems.Concat(current) 
                : sameCapacityItems;
        }
    }
}