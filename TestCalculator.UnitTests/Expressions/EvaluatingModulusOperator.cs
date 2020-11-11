using FluentAssertions;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingModulusOperator : FixtureBase
    {
        [Fact]
        void ShouldReturnRemainderOfTwoExpressions()
        {
            var expression1 = Create<NumberLiteral>();
            var expression2 = Create<NumberLiteral>();
            var expectedResult = expression1.Result % expression2.Result;

            var addition = new ModulusOperator(expression1, expression2);

            addition.Result.Should().Be(expectedResult);
        }
    }
}
