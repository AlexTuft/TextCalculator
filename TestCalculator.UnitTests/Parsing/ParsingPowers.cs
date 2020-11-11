using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingPowers
    {
        [Theory]
        [InlineData("1 ^ 2")]
        void ShouldReturnPowerOperator(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<PowerOperator>(new NumberLiteral(1), new NumberLiteral(2));
        }

        [Theory]
        [InlineData("1 ^ 2 ^ 3")]
        void ShouldHandlePowersMultiplications(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<PowerOperator>(
                new PowerOperator(
                    new NumberLiteral(1),
                    new NumberLiteral(2)),
                new NumberLiteral(3));
        }

        [Theory]
        [InlineData("1 * 2 ^ 3")]
        void ShouldShouldPrecedeMultiplication(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<MultiplicationOperator>(
                new NumberLiteral(1),
                new PowerOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }

        [Theory]
        [InlineData("1 / 2 ^ 3")]
        void ShouldShouldPrecedeDivision(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<DivisionOperator>(
                new NumberLiteral(1),
                new PowerOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }

        [Theory]
        [InlineData("1 % 2 ^ 3")]
        void ShouldShouldPrecedeModulus(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<ModulusOperator>(
                new NumberLiteral(1),
                new PowerOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }
    }
}
