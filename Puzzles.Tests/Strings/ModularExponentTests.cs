using FluentAssertions;
using Puzzles.Exercises.Strings;
using Xunit;

namespace Puzzles.Tests.Strings
{
    public class ModularExponentTests
    {
        [Theory]
        //[InlineData(5, 5, 7, 3)]
        //[InlineData(5, 0, 6, 1)]
        [InlineData(5, 117, 19, 1)]
        public void ModularExponentRaisesToPowerByModulus(long number, long degree, long modulus, long expected)
        {
            // SUT
            var exponent = new ModularExponent(number, degree, modulus);

            // ASSERT
            exponent.Value.Should().Be(expected);
        }
    }
}