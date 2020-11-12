using FluentAssertions;
using System;
using TextCalculator.Expressions;
using Xunit;

namespace TextCalculator.UnitTests.Expressions
{
    public class EvaluatingAbsoluteValue : FixtureBase
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        void ShouldReturnAbsoluteValueOfExpression(int input)
        {
            var number = new AbsoluteValue(new NumberLiteral(input));

            number.Result.Should().Be(Math.Abs(input));
        }
    }
}
