using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingMultiplication
    {
        [Theory]
        [InlineData("1 * 2")]
        void ShouldReturnMultiplicationOperator(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<MultiplicationOperator>(new NumberLiteral(1), new NumberLiteral(2));
        }

        [Theory]
        [InlineData("1 * 2 * 3")]
        void ShouldHandleMultipleMultiplications(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<MultiplicationOperator>(
                new MultiplicationOperator(
                    new NumberLiteral(1),
                    new NumberLiteral(2)),
                new NumberLiteral(3));
        }

        [Theory]
        [InlineData("1 + 2 * 3")]
        void ShouldShouldPrecedeAddition(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<AdditionOperator>(
                new NumberLiteral(1),
                new MultiplicationOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }

        [Theory]
        [InlineData("1 - 2 * 3")]
        void ShouldShouldPrecedeSubtraction(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<SubtractionOperator>(
                new NumberLiteral(1),
                new MultiplicationOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }
    }
}
