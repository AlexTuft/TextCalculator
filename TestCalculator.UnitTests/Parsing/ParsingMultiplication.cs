using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingMultiplication
    {
        [Theory]
        [InlineData("1 * 2", "mul(num{1},num{2})")]
        void ShouldReturnMultiplicationOperator(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 * 2 * 3", "mul(mul(num{1},num{2}),num{3})")]
        void ShouldHandleMultipleMultiplications(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 + 2 * 3", "add(num{1},mul(num{2},num{3}))")]
        void ShouldShouldPrecedeAddition(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 - 2 * 3", "sub(num{1},mul(num{2},num{3}))")]
        void ShouldShouldPrecedeSubtraction(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
