using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingNumberLiteral : FixtureBase
    {
        [Theory]
        [InlineData("1", "num{1}")]
        [InlineData("12", "num{12}")]
        [InlineData("123", "num{123}")]
        void ShouldReturnNumberLiteral(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1.2", "num{1.2}")]
        [InlineData(".1", "num{0.1}")]
        [InlineData("1.", "num{1}")]
        void ShouldParseDecimalNumbers(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1.2.3", 3)]
        [InlineData("1..23", 2)]
        [InlineData(".23.", 3)]
        void ShouldThrowBadInputFormatIfContainsMoreThanOneDecimalPoint(string input, int errorIndex)
        {
            ParserTest.RunErrorCase(input, errorIndex);
        }

        [Theory]
        [InlineData("-1", "num{-1}")]
        [InlineData("+1", "num{1}")]
        [InlineData("-1.2", "num{-1.2}")]
        [InlineData("+1.2", "num{1.2}")]
        void ShouldParseSignSymbol(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
