﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [InlineData(new [] {0})]
        public void ElementsAreSortedInDecreasingOrder(params int[][] arrays)
        {
            // SUT
            var mergedArray = new MergedSortedArray(arrays);

            // ACT
            var actual = mergedArray.MergedArray;

            // ASSERT
            actual.Should().BeInDescendingOrder();
        }
    }
}