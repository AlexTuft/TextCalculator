using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingAddition : FixtureBase
    {
        [Theory]
        [InlineData("1 + 2")]
        void ShouldReturnAdditionOperator(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeAdditionOperator(new NumberLiteral(1), new NumberLiteral(2));
        }

        [Theory]
        [InlineData("1 + 2 + 3")]
        void ShouldHandleMultipleAdditions(string input)
        {
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeAdditionOperator(
                new AdditionOperator(
                    new NumberLiteral(1),
                    new NumberLiteral(2)),
                new NumberLiteral(3));
        }
    }
}
