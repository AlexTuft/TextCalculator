using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingPowers
    {
        [Theory]
        [InlineData("1 ^ 2", "pow(num{1},num{2})")]
        void ShouldReturnPowerOperator(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 ^ 2 ^ 3", "pow(pow(num{1},num{2}),num{3})")]
        void ShouldHandlePowersMultiplications(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 * 2 ^ 3", "mul(num{1},pow(num{2},num{3}))")]
        void ShouldShouldPrecedeMultiplication(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 / 2 ^ 3", "div(num{1},pow(num{2},num{3}))")]
        void ShouldShouldPrecedeDivision(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 % 2 ^ 3", "mod(num{1},pow(num{2},num{3}))")]
        void ShouldShouldPrecedeModulus(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
