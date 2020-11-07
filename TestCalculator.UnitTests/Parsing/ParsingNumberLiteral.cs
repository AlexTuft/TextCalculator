using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingNumberLiteral : FixtureBase
    {
        [Theory]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("123")]
        void ShouldReturnNumberLiteral(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeNumberLiteral(int.Parse(input));
        }
    }
}
