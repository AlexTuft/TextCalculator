using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingModulus
    {
        [Theory]
        [InlineData("1 % 2")]
        void ShouldReturnModulusOperator(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<ModulusOperator>(new NumberLiteral(1), new NumberLiteral(2));
        }

        [Theory]
        [InlineData("1 % 2 % 3")]
        void ShouldHandleMultipleModuluss(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<ModulusOperator>(
                new ModulusOperator(
                    new NumberLiteral(1),
                    new NumberLiteral(2)),
                new NumberLiteral(3));
        }

        [Theory]
        [InlineData("1 + 2 % 3")]
        void ShouldShouldPrecedeAddition(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<AdditionOperator>(
                new NumberLiteral(1),
                new ModulusOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }

        [Theory]
        [InlineData("1 - 2 % 3")]
        void ShouldShouldPrecedeSubtraction(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<SubtractionOperator>(
                new NumberLiteral(1),
                new ModulusOperator(
                    new NumberLiteral(2),
                    new NumberLiteral(3)));
        }
    }
}
