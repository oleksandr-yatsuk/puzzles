using System.Linq;
using FluentAssertions;
using Puzzles.Common;
using Puzzles.Exercises.Knapsack;
using Xunit;
using Xunit.Sdk;

namespace Puzzles.Tests.Knapsack
{
    public class KnapsackTests
    {
        [Theory]
        [InlineData(new[] { 1 }, new[] { 1 }, 1, 1)]
        [InlineData(new[] { 3, 2, 3, 5, 2 }, new[] { 1, 4, 4, 3, 1 }, 10, 13)]
        [InlineData(new[] { 3, 3 }, new[] { 1, 1 }, 1, 3)]
        [InlineData(new[] { 3, 3 }, new[] { 1, 1 }, 0, 0)]
        public void GetMaximumValue_CalculatesMaximumValueForCapacity(int[] values, int[] weights, int capacity, int expectedValue)
        {
            // ARRANGE
            var items = values.Select((value, i) => new Item(value, weights[i])).ToArray();

            // SUT
            var backpack = new Backpack(capacity);

            // ACT
            var actualValue = backpack.GetMaximumValue(items);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void GetMaximumValue_WorksFasterThenBruteforce()
        {
            // ARRANGE
            const int weight = 3;
            const int numberOfItems = 25;

            var items = Enumerable.Range(1, numberOfItems).Select((value, i) => new Item(value, weight)).ToArray();

            const int capacity = 203;

            // SUT
            var backpack = new Backpack(capacity);

            // ACT
            var actualBruteForceValue = new ExecutionTime(() => backpack.GetMaximumValueRecursively(items)).ExecuteAndMeasure();
            var actualValue = new ExecutionTime(() => backpack.GetMaximumValue(items)).ExecuteAndMeasure();
            
            // ASSERT
            actualValue.Should().BeLessThan(actualBruteForceValue);
        }
    }
}