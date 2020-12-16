using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingParenthesis
    {
        [Theory]
        [InlineData("(1)", "num{1}")]
        void ShouldReturnNumberLiteralIfIsOnlyTokenInsideParenthesis(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("(1 + 1)", "add(num{1},num{1})")]
        void ShouldReturnBinaryOperatorIfIsOnlyTokenInsideParenthesis(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 * (2 * 3 + 4) + 5", "add(mul(num{1},add(mul(num{2},num{3}),num{4})),num{5})")]
        void ShouldEvaluateParenthesisFirst(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
