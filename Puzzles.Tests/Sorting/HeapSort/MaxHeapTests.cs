using FluentAssertions;
using Puzzles.Exercises.Sorting.HeapSort;
using Xunit;

namespace Puzzles.Tests.Sorting.HeapSort
{
    public class MaxHeapTests
    {
        [Fact]
        public void MaxHeapify_MaxifiesTheSubTree()
        {
            // ARRANGE
            var heapValues = new[]
            {
                16,
                4, 10,
                14, 7, 9, 3,
                2, 8, 1
            };

            var expectedHeapValues = new[]
            {
                16,
                14, 10,
                8, 7, 9, 3,
                2, 4, 1
            };

            var expectedHeap = new Heap<int>(expectedHeapValues);

            // SUT
            var maxHeap = new MaxHeap(new Heap<int>(heapValues));

            // ACT
            maxHeap.MaxHeapify(1);

            // ASSERT
            maxHeap.Heap.Equals(expectedHeap).Should().BeTrue();
        }
    }
}