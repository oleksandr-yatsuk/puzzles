using FluentAssertions;
using Puzzles.Exercises.Sorting.QuickSort;
using Xunit;

namespace Puzzles.Tests.Sorting.QuickSort
{
    public class SortedArrayTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 2, 3, 4, 1, 5 })]
        [InlineData(new[] { 2, 33, 14, 11, 25 })]
        [InlineData(new[] { 1, 2, 3, 4, 4, 4, 3, 2, 1 })]
        [InlineData(new[] { 5, 4, 3, 2, 1 })]
        public void ArrayOfNumbersGetsRecursivelySorted(int[] numbers)
        {
            // SUT
            var array = new SortedArray(numbers);

            // ACT
            var sortedNumbers = array.RecursivelySorted;

            // ASSERT
            sortedNumbers.Should().Contain(numbers);
            sortedNumbers.Should().BeInDescendingOrder();
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 2, 3, 4, 1, 5 })]
        [InlineData(new[] { 2, 33, 14, 11, 25 })]
        [InlineData(new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 4, 4, 3, 2, 1 })]
        public void ArrayOfNumbersGetsSorted(int[] numbers)
        {
            // SUT
            var array = new SortedArray(numbers);

            // ACT
            var sortedNumbers = array.Sorted;

            // ASSERT
            sortedNumbers.Should().Contain(numbers);
            sortedNumbers.Should().BeInDescendingOrder();
        }
    }
}