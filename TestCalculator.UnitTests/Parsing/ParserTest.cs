using FluentAssertions;
using System;
using TextCalculator.Expressions;
using TextCalculator.Parsing;

namespace TextCalculator.UnitTests.Parsing
{
    public static class ParserTest
    {
        internal static void RunCase(string input, string expectedOutput)
        {
            var parser = new Parser();
            var expression = parser.Parse(input);

            if (expectedOutput != null)
            {
                expression.Should().NotBeNull();
                expression.ToText().Should().Be(expectedOutput);
            }
            else
            {
                expression.Should().BeNull();
            }
        }

        internal static void RunErrorCase(string input, int errorIndex)
        {
            var parser = new Parser();
            Action action = () => parser.Parse(input);

            action.Should().Throw<BadInputFormat>()
                .Where(x => x.ErrorIndex == errorIndex);
        }

        internal static string ToText(this IExpression ex)
        {
            if (ex is NumberLiteral num)
            {
                return $"num{{{num.Result}}}";
            }
            else if (ex is AdditionOperator add)
            {
                return $"add({add.LeftExpression.ToText()},{add.RightExpression.ToText()})";
            }
            else if (ex is SubtractionOperator sub)
            {
                return $"sub({sub.LeftExpression.ToText()},{sub.RightExpression.ToText()})";
            }
            else if (ex is MultiplicationOperator mul)
            {
                return $"mul({mul.LeftExpression.ToText()},{mul.RightExpression.ToText()})";
            }
            else if (ex is DivisionOperator div)
            {
                return $"div({div.LeftExpression.ToText()},{div.RightExpression.ToText()})";
            }
            else if (ex is ModulusOperator mod)
            {
                return $"mod({mod.LeftExpression.ToText()},{mod.RightExpression.ToText()})";
            }
            else if (ex is PowerOperator pow)
            {
                return $"pow({pow.LeftExpression.ToText()},{pow.RightExpression.ToText()})";
            }
            else if (ex is AbsoluteValue abs)
            {
                return $"abs({abs.InnerExpression.ToText()})";
            }

            throw new ArgumentException("Unsupported type.");
        }
    }
}
