using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingDivision
    {
        [Theory]
        [InlineData("1 / 2", "div(num{1},num{2})")]
        void ShouldReturnDivisionOperator(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 / 2 / 3", "div(div(num{1},num{2}),num{3})")]
        void ShouldHandleMultipleDivisions(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 + 2 / 3", "add(num{1},div(num{2},num{3}))")]
        void ShouldShouldPrecedeAddition(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 - 2 / 3", "sub(num{1},div(num{2},num{3}))")]
        void ShouldShouldPrecedeSubtraction(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
