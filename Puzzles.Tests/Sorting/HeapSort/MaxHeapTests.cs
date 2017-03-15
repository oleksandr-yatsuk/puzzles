using System.Linq;
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

        [Fact]
        public void BuildMaxHeap_MakesEachNodeMaxRootOfItsSubTree()
        {
            // ARRANGE
            var heapValues = new[]
            {
                4,
                1, 3,
                2, 16, 9, 10,
                14, 8, 7
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
            maxHeap.BuildMaxHeap();

            // ASSERT
            maxHeap.Heap.Equals(expectedHeap).Should().BeTrue();
        }

        [Fact]
        public void Sort_SortsHeap()
        {
            // ARRANGE
            var heapValues = new[]
            {
                10, 9, 8, 7, 6, 5, 4, 3, 2, 1
            };

            var expectedHeapValues = heapValues.OrderBy(v => v);
            var expectedHeap = new Heap<int>(expectedHeapValues);

            // SUT
            var maxHeap = new MaxHeap(new Heap<int>(heapValues));

            // ACT
            maxHeap.Sort();

            // ASSERT
            maxHeap.Heap.Equals(expectedHeap).Should().BeTrue();
        }

        [Fact]
        public void Sort_KeepsOriginalSizeOfTheHeap()
        {
            // ARRANGE
            var heapValues = new[] { 4, 1, 3 };

            // SUT
            var maxHeap = new MaxHeap(new Heap<int>(heapValues));

            // ACT
            maxHeap.Sort();

            // ASSERT
            maxHeap.HeapSize.Should().Be(heapValues.Length);
        }
    }
}