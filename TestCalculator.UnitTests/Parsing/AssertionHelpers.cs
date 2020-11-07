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
    }
}
