using FluentAssertions;
using Puzzles.Exercises.Strings.PerfectSubsequences;
using Xunit;

namespace Puzzles.Tests.Strings.PerfectSubsequences
{
    public class DegreeValueTests
    {
        [Theory]
        [InlineData(5, 2, 12, 1)]
        [InlineData(1111, 1111, 1112, 1111)]
        [InlineData(25, 25, 77, 67)]
        [InlineData(258, 963, 147, 6)]
        public void NumberIsRaisedToAPowerByModule(long number, long degree, long modulus, long expected)
        {
            // SUT
            var degreeValue = new DegreeValue(number, degree, modulus);

            // ASSERT
            degreeValue.Value.Should().Be(expected);
        }

        [Theory]
        [InlineData(12, 47)]
        [InlineData(47, 5)]
        [InlineData(8996, 56)]
        public void ResultIsOneIfDegreeIsZero(long number, long modulus)
        {
            // SUT
            var degreeValue = new DegreeValue(number, 0, modulus);

            // ASSERT
            degreeValue.Value.Should().Be(1);
        }
    }
}