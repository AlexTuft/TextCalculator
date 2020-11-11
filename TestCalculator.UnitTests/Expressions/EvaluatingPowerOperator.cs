using FluentAssertions;
using System;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingPowerOperator : FixtureBase
    {
        [Fact]
        void ShouldReturnExpression1RaisedToPowerOfExpression2()
        {
            var expression1 = Create<NumberLiteral>();
            var expression2 = Create<NumberLiteral>();
            var expectedResult = Math.Pow(expression1.Result, expression2.Result);

            var addition = new PowerOperator(expression1, expression2);

            addition.Result.Should().Be(expectedResult);
        }
    }
}
