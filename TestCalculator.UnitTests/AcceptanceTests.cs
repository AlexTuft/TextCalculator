using FluentAssertions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class AcceptanceTests : FixtureBase
    {
        [Theory]
        [InlineData("2 + 4", 6)]
        [InlineData("5 - 41", -36)]
        [InlineData("32 * -45", -1440)]
        [InlineData(" -12 + 45 - 3", 30)]
        [InlineData("-3 + 100 / 4", 22)]
        void RunCase(string input, double expectedOutput)
        {
            var parser = new Parser();
            var expression = parser.Parse(input);

            if (expression is null)
            {
                true.Should().BeFalse(); // FAIL
            }
            else
            {
                expression.Result.Should().Be(expectedOutput);
            }
        }
    }
}
