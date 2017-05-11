using FluentAssertions;
using Puzzles.Exercises.Sorting.InsertionSort;
using Xunit;

namespace Puzzles.Tests.Sorting.InsertionSort
{
    public class SortedArrayTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 2, 33, 14, 11, 25 })]
        [InlineData(new[] { 5, 4, 3, 2, 1 })]
        public void ArrayOfNumbersGetsSorted(int[] numbers)
        {
            // SUT
            var array = new SortedArray(numbers);

            // ACT
            var sortedNumbers = array.DescendingNumbers;

            // ASSERT
            sortedNumbers.Should().BeInDescendingOrder();
        }

        [Theory]
        [InlineData(new[] { 1, 20, 3, 14, 5 })]
        [InlineData(new[] { 2, 3, 4, 1, 5 })]
        [InlineData(new[] { 5, 4, 3, 2, 1 })]
        public void ArrayOfNumbersGetsSortedInAscendingOrder(int[] numbers)
        {
            // SUT
            var array = new SortedArray(numbers);

            // ACT
            var sortedNumbers = array.Numbers;

            // ASSERT
            sortedNumbers.Should().BeInAscendingOrder();
        }
    }
}