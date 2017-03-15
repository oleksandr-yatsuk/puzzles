using FluentAssertions;
using Puzzles.Exercises.Sorting.HeapSort;
using Xunit;

namespace Puzzles.Tests.Sorting.HeapSort
{
    public class HeapTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 3)]
        [InlineData(7, 15)]
        public void Left_GetsTheLeftChild(int node, int left)
        {
            // ARRANGE
            var heapValues = new[]
            {
                16,
                4, 10,
                14, 7, 9, 3,
                2, 8, 1
            };

            // SUT
            var heap = new Heap<int>(heapValues);

            // ACT
            var actual = heap.Left(node);

            // ASSERT
            actual.Should().Be(left);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(6, 3)]
        public void LeafsIndex_GetsTheMinimumIndexAmongAllLeafs(int heapSize, int leafsIndex)
        {
            // ARRANGE
            var heapValues = new int[heapSize];

            // SUT
            var heap = new Heap<int>(heapValues);

            // ACT & ASSERT
            heap.LeafsIndex.Should().Be(leafsIndex);
        }
    }
}