using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingAddition : FixtureBase
    {
        [Theory]
        [InlineData("1 + 2", "add(num{1},num{2})")]
        void ShouldReturnExpectedValue(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 + 2 + 3", "add(add(num{1},num{2}),num{3})")]
        void ShouldHandleMultipleAdditions(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
