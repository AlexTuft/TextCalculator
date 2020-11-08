using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingSubtraction
    {
        [Theory]
        [InlineData("1 - 2")]
        void ShouldReturnSubtractionOperator(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<SubtractionOperator>(new NumberLiteral(1), new NumberLiteral(2));
        }

        [Theory]
        [InlineData("1 - 2 - 3")]
        void ShouldHandleMultipleSubtractions(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<SubtractionOperator>(
                new SubtractionOperator(
                    new NumberLiteral(1),
                    new NumberLiteral(2)),
                new NumberLiteral(3));
        }
    }
}
