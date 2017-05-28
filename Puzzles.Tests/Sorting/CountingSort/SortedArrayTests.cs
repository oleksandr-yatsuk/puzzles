using FluentAssertions;
using Puzzles.Exercises.Sorting.CountingSort;
using Xunit;

namespace Puzzles.Tests.Sorting.CountingSort
{
    public class SortedArrayTests
    {
        [Theory]
        [InlineData(new [] {1, 2, 3, 4, 5, 1}, 5)]
        [InlineData(new [] {1, 1, 9, 7}, 9)]
        [InlineData(new [] {10, 5, 4, 3}, 15)]
        [InlineData(new [] {1, 2, 2, 2, 2, 1, 1, 2, 1}, 2)]
        [InlineData(new [] {77, 55, 11, 4, 74, 99, 0, 12, 11, 9}, 100)]
        public void ValuesAreSortedInAscendingOrder(int[] values, int max)
        {
            // SUT
            var array = new SortedArray(values, max);

            // ACT
            var actual = array.SortedValues;

            // ASSERT
            actual.Should().BeInAscendingOrder();
        }

        [Theory]
        [InlineData(new [] {1, 2, 3, 4, 5, 1}, 5)]
        [InlineData(new [] {1, 1, 9, 7}, 9)]
        [InlineData(new [] {10, 5, 4, 3}, 15)]
        [InlineData(new [] {1, 2, 2, 2, 2, 1, 1, 2, 1}, 2)]
        [InlineData(new [] {77, 55, 11, 4, 74, 99, 0, 12, 11, 9}, 100)]
        public void ValuesAreSortedInDescendingOrder(int[] values, int max)
        {
            // SUT
            var array = new SortedArray(values, max);

            // ACT
            var actual = array.DescendingSortedValues;

            // ASSERT
            actual.Should().BeInDescendingOrder();
        }
    }
}