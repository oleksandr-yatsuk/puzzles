using System.Linq;
using FluentAssertions;
using Puzzles.Exercises.Knapsack;
using Xunit;

namespace Puzzles.Tests.Knapsack
{
    public class RecursiveAndBruteForceKnapsackTests
    {
        [Theory]
        [InlineData(new []{1}, new []{1}, 1, 1)]
        [InlineData(new []{3, 2, 3, 5, 2}, new []{1, 4, 4, 3, 1}, 10, 13)]
        [InlineData(new []{3, 3}, new []{1, 1}, 1, 3)]
        [InlineData(new []{3, 3}, new []{1, 1}, 0, 0)]
        public void GetMaximumValueRecursively_CalculatesMaximumValueForCapacity(int[] values, int[] weights, int capacity, int expectedValue)
        {
            // ARRANGE
            var items = values.Select((value, i) => new Item(value, weights[i])).ToArray();

            // SUT
            var backpack = new Backpack(capacity);

            // ACT
            var actualValue = backpack.GetMaximumValueRecursively(items);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(new []{1}, new []{1}, 1, 1)]
        [InlineData(new []{3, 2, 3, 5, 2}, new []{1, 4, 4, 3, 1}, 10, 13)]
        [InlineData(new []{3, 3}, new []{1, 1}, 1, 3)]
        [InlineData(new []{3, 3}, new []{1, 1}, 0, 0)]
        public void GetMaximumValueBruteForce_CalculatesMaximumValueForCapacity(int[] values, int[] weights, int capacity, int expectedValue)
        {
            // ARRANGE
            var items = values.Select((value, i) => new Item(value, weights[i])).ToArray();

            // SUT
            var backpack = new Backpack(capacity);

            // ACT
            var actualValue = backpack.GetMaximumValueBruteForce(items);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void GetMaxValuableItems_GetsItemsComposedMaximumValue()
        {
            // ARRANGE
            var items = new[]
            {
                new Item(3, 1), 
                new Item(2, 4), 
                new Item(3, 4), 
                new Item(5, 3), 
                new Item(2, 1)
            };

            const int capacity = 12;
            const int expectedValue = 13;

            // SUT
            var backpack = new Backpack(capacity);

            // ACT
            var actual = backpack.GetMaximumValuableContent(items);

            // ASSERT
            actual.Sum(i => i.Value).Should().Be(expectedValue);
        }
    }
}