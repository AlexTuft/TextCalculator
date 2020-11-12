using TextCalculator.Expressions;
using TextCalculator.Parsing;
using Xunit;

namespace TextCalculator.UnitTests.Parsing
{
    public class ParsingParenthesis
    {
        [Fact]
        void ShouldReturnNumberLiteralIfIsOnlyTokenInsideParenthesis()
        {
            var input = "(1)";

            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeNumberLiteral(1);
        }

        [Fact]
        void ShouldReturnBinaryOperatorIfIsOnlyTokenInsideParenthesis()
        {
            var input = "(1 + 1)";
            
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<AdditionOperator>(new NumberLiteral(1), new NumberLiteral(1));
        }

        [Fact]
        void ShouldEvaluateParenthesisFirst()
        {
            var input = "1 * (2 * 3 + 4) + 5";
            
            var parser = new Parser();

            var expression = parser.Parse(input);

            expression.ShouldBeBinaryOperator<AdditionOperator>(
                new MultiplicationOperator(
                    new NumberLiteral(1),
                    new AdditionOperator(
                        new MultiplicationOperator(
                            new NumberLiteral(2),
                            new NumberLiteral(3)),
                        new NumberLiteral(4))
                ),
                new NumberLiteral(5));
        }
    }
}
