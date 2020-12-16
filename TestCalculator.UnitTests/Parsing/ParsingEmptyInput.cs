using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingEmptyInput
    {
        [Theory]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("    ", null)]
        void ShouldReturnNull(string input, string output)
        {
            ParserTest.RunCase(input, output);
        }
    }
}
