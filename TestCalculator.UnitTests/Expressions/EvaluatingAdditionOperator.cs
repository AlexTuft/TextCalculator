using FluentAssertions;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingAdditionOperator : FixtureBase
    {
        [Fact]
        void ShouldReturnSumOfTwoExpressions()
        {
            var expression1 = Create<NumberLiteral>();
            var expression2 = Create<NumberLiteral>();
            var expectedResult = expression1.Result + expression2.Result;

            var addition = new AdditionOperator(expression1, expression2);

            addition.Result.Should().Be(expectedResult);
        }
    }
}
