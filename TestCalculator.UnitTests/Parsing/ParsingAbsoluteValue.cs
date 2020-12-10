using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingAbsoluteValue
    {
        [Fact]
        void ShouldReturnNumberLiteralIfIsOnlyTokenInsideAbsoluteValue()
        {
            var input = "|-1|";

            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeExpression<AbsoluteValue>(1);
        }

        [Fact]
        void ShouldReturnBinaryOperatorIfIsOnlyTokenInsideAbsoluteValue()
        {
            var input = "|1 - 3|";

            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeExpression<AbsoluteValue>(2);
        }
    }
}
