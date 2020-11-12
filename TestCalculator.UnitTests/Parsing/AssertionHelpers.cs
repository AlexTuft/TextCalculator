using FluentAssertions;
using TextCalculator.Expressions;

namespace TextCalculator.UnitTests.Parsing
{
    internal static class AssertionHelpers
    {
        internal static void ShouldBeNumberLiteral(this object? o, double value)
        {
            o.ShouldBeExpression<NumberLiteral>(value);
        }
        
        internal static void ShouldBeExpression<TExpression>(this object? o, double value) where TExpression : IExpression
        {
            o.Should().BeOfType<TExpression>();
            o.As<TExpression>().Result.Should().Be(value);
        }

        internal static void ShouldBeBinaryOperator<TOperator>(this object? o, IExpression left, IExpression right) where TOperator : IBinaryOperator
        {
            o.Should().BeOfType<TOperator>();

            if (o is TOperator a)
            {
                // Assert that expressions are correct type
                a.LeftExpression.Should().BeOfType(left.GetType());
                a.RightExpression.Should().BeOfType(right.GetType());

                // Assert that expressions are correct value
                a.LeftExpression.Result.Should().Be(left.Result);
                a.RightExpression.Result.Should().Be(right.Result);
            }
        }
    }
}
