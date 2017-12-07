using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Puzzles.Tests.CompositeIndexes
{
    public class CompositeIndexesTests
    {
        [Fact]
        public void IndexesEnumerateAllPossibleResults()
        {
            // ARRANGE
            const int length = 11;
            const int maxValue = 3;

            var expectedNumberOfIndexes = (long)Math.Pow(maxValue + 1, length);

            // SUT
            var indexes = new Exercises.Probability.Palindromes.ExpectedValue.CompositeIndexes(maxValue, length);

            // ASSERT
            indexes.ToArray().LongLength.Should().Be(expectedNumberOfIndexes);
        }

        [Fact]
        public void IndexesEnumerateDifferentResults()
        {
            // ARRANGE
            const int length = 3;
            const int maxValue = 8;

            var expectedNumberOfIndexes = (long)Math.Pow(maxValue + 1, length);

            // SUT
            var indexes = new Exercises.Probability.Palindromes.ExpectedValue.CompositeIndexes(maxValue, length);

            // ASSERT
            indexes.ToArray()
                .Select(a => string.Join("|", a))
                .Distinct()
                .ToArray()
                .LongLength.Should().Be(expectedNumberOfIndexes);
        }
    }
}