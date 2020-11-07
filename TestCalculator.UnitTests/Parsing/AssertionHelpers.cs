using FluentAssertions;
using TextCalculator.Expressions;

namespace TextCalculator.UnitTests.Parsing
{
    internal static class AssertionHelpers
    {
        internal static void ShouldBeNumberLiteral(this object? o, double value)
        {
            o.Should().BeOfType<NumberLiteral>();
            o.As<NumberLiteral>().Result.Should().Be(value);
        }

        internal static void ShouldBeAdditionOperator(this object? o, IExpression left, IExpression right)
        {
            o.Should().BeOfType<AdditionOperator>();

            if (o is AdditionOperator a)
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
