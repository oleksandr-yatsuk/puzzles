using FluentAssertions;
using Puzzles.Exercises.Sorting.MergeSort;
using Xunit;

namespace Puzzles.Tests.Sorting.MergeSort
{
    public class MergeSrotedArrayTests
    {
        [Theory]
        [InlineData(new[] {1, 2, -3, 4, 5})]
        [InlineData(new[] {2, 3, 4, 1, 5})]
        [InlineData(new[] {2, 33, 14, 11, 25})]
        [InlineData(new[] {1, 2, 3, 4, 4, 4, 3, 2, 1})]
        [InlineData(new[] {1, 2, 3, 4, 4, 3, 2, 1})]
        [InlineData(new[] {5, 4, 3, 2, 1})]
        [InlineData(new[] {50, 114, 32, 205, 11, -47, -78, 0, 0, -4, 44, 52})]
        public void NumbersGetTopDownSortedInAscOrder(int[] numbers)
        {
            // SUT
            var array = new SortedArray(numbers);

            // ACT
            var actual = array.SortedTopDown;

            // ASSERT
            actual.Should().Contain(numbers);
            actual.Should().BeInAscendingOrder();
        }
    }
}