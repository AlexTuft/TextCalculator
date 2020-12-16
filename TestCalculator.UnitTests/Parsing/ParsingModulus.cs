using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingModulus
    {
        [Theory]
        [InlineData("1 % 2", "mod(num{1},num{2})")]
        void ShouldReturnModulusOperator(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 % 2 % 3", "mod(mod(num{1},num{2}),num{3})")]
        void ShouldHandleMultipleModuluss(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 + 2 % 3", "add(num{1},mod(num{2},num{3}))")]
        void ShouldShouldPrecedeAddition(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 - 2 % 3", "sub(num{1},mod(num{2},num{3}))")]
        void ShouldShouldPrecedeSubtraction(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
