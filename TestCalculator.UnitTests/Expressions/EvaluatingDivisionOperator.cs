using FluentAssertions;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingDivisionOperator : FixtureBase
    {
        [Fact]
        void ShouldReturnQuotientOfTwoExpressions()
        {
            var expression1 = Create<NumberLiteral>();
            var expression2 = Create<NumberLiteral>();
            var expectedResult = expression1.Result / expression2.Result;

            var addition = new DivisionOperator(expression1, expression2);

            addition.Result.Should().Be(expectedResult);
        }
    }
}
