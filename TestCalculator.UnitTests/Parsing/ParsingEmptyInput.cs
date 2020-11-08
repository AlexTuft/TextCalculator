using FluentAssertions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingEmptyInput
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("    ")]
        void ShouldReturnNull(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.Should().BeNull();
        }
    }
}
