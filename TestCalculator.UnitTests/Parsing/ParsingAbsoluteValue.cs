using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingAbsoluteValue
    {
        [Theory]
        [InlineData("|-1|", "abs(num{-1})")]
        [InlineData("|1-2|", "abs(sub(num{1},num{2}))")]
        void ShouldReturnExpectedValue(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
