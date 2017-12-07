using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public int GetMaximumValueBruteForce(Item[] items)
        {
            var n = items.Length;
            var indexes = new CompositeIndexes(1, n);

            var result = 0;

            foreach (var index in indexes)
            {
                var current = items.Where((item, i) => index[i] == 1).ToArray();
                var weight = current.Sum(item => item.Weight);

                if (weight > Capacity) continue;

                var value = current.Sum(item => item.Value);

                if (value > result)
                    result = value;
            }

            return result;
        }

        public int GetMaximumValue(Item[] items)
        {
            var decisionsMatrix = new Matrix<int>(items.Length, Capacity + 1, -1);

            return CalculateMaximumValue(items, items.Length - 1, Capacity, decisionsMatrix);
        }

        static int CalculateMaximumValue(Item[] items, int current, int capacity, Matrix<int> decisionsMatrix)
        {
            if (capacity <= 0 || current < 0)
                return 0;

            if (decisionsMatrix[current, capacity] >= 0)
                return decisionsMatrix[current, capacity];

            var sameCapacityValue = CalculateMaximumValue(items, current - 1, capacity, decisionsMatrix);
            var currentItem = items[current];

            if (currentItem.Weight > capacity)
                return sameCapacityValue;

            var prevItemValue = CalculateMaximumValue(items, current - 1, capacity - currentItem.Weight, decisionsMatrix) + currentItem.Value;

            var maxValue = Math.Max(sameCapacityValue, prevItemValue);

            decisionsMatrix[current, capacity] = maxValue;

            return maxValue;
        }

        static int GetMaximumValueRecursively(Item[] items, int capacity, int n)
        {
            if (capacity <= 0 || n < 0)
                return 0;

            var sameCapacityValue = GetMaximumValueRecursively(items, capacity, n - 1);
            var current = items[n];

            if (capacity < current.Weight)
                return sameCapacityValue;

            var currentCapacityValue = GetMaximumValueRecursively(items, capacity - current.Weight, n - 1) + current.Value;
            var value = Math.Max(sameCapacityValue, currentCapacityValue);

            return value;
        }

        static Item[] GetMaxValuableItemsRecursively(Item[] items, int capacity, int n)
        {
            if (capacity <= 0 || n < 0) return Enumerable.Empty<Item>().ToArray();

            var sameCapacityItems = GetMaxValuableItemsRecursively(items, capacity, n - 1);
            var current = items[n];

            if (capacity < current.Weight) return sameCapacityItems;

            var currentCapacityItems = GetMaxValuableItemsRecursively(items, capacity - current.Weight, n - 1);

            var sameCapacityValue = sameCapacityItems.Sum(item => item.Value);
            var currentCapacityValue = currentCapacityItems.Sum(item => item.Value) + current.Value;

            return currentCapacityValue > sameCapacityValue 
                ? currentCapacityItems.Concat(current) 
                : sameCapacityItems;
        }
    }
}