using FluentAssertions;
using Puzzles.Exercises.Sorting.HeapSort;
using Xunit;

namespace Puzzles.Tests.Sorting.HeapSort
{
    public class MergedSortedArrayTests
    {
        [Theory]
        [InlineData(new [] {10, 5, 1}, new[] {1, -5, -10}, new[] {100, 77, 52})]
        [InlineData(new [] {10, 5, 1})]
        [InlineData(new [] {1, 1, 1, -1})]
        public void ElementsAreSortedInDecreasingOrder(params int[][] arrays)
        {
            // SUT
            var mergedArray = new MergedSortedArray(arrays);

            // ACT
            var actual = mergedArray.MergedArray;

            // ASSERT
            actual.Should().BeInDescendingOrder();
        }

        [Theory]
        [InlineData(new [] {10, 5, 1}, new[] {1, 2, 1})]
        [InlineData(new [] {4, 5, 1})]
        public void ElementsAreNotSortedIfArraysAreNot(params int[][] arrays)
        {
            // SUT
            var mergedArray = new MergedSortedArray(arrays);

            // ACT
            var actual = mergedArray.MergedArray;

            // ASSERT
            actual.Should().NotBeDescendingInOrder();
            actual.Should().NotBeAscendingInOrder();
        }
    }
}