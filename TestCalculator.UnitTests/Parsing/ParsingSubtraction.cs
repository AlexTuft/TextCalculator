using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingSubtraction
    {
        [Theory]
        [InlineData("1 - 2", "sub(num{1},num{2})")]
        void ShouldReturnSubtractionOperator(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }

        [Theory]
        [InlineData("1 - 2 - 3", "sub(sub(num{1},num{2}),num{3})")]
        void ShouldHandleMultipleSubtractions(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
