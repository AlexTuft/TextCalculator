using System.Collections.Generic;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal static class ParsingPipeline
    {
        internal static IParser Create()
        {
            // Declare in order of preceedence, except for parenthesis and absolute value, where order doesn't matter.
            var numberLiteralParser = new NumberLiteralParser();
            var parenthesisParser = GetParenthesisParser(numberLiteralParser);
            var absoluteValueParser = GetAbsoluteValueParser(parenthesisParser);
            var powerParser = GetPowerParser(absoluteValueParser);
            var multiplyAndDivideParser = GetMultiplyAndDivideParser(powerParser);
            var addAndSubtractParser = GetAddAndSubtractParser(multiplyAndDivideParser);

            parenthesisParser.Start = addAndSubtractParser;
            absoluteValueParser.Start = addAndSubtractParser;

            return addAndSubtractParser;
        }

        private static GroupingParser GetParenthesisParser(IParser next)
        {
            return new GroupingParser('(', ')', x => x, next);
        }

        private static GroupingParser GetAbsoluteValueParser(IParser next)
        {
            return new GroupingParser('|', '|', x => new AbsoluteValue(x), next);
        }

        private static BinaryOperatorParser GetPowerParser(IParser next)
        {
            return new BinaryOperatorParser(new Dictionary<char, BinaryOperatorFactory>
                    {
                        { '^', (l, r) => new PowerOperator(l, r) },
                    },
                                    next);
        }

        private static BinaryOperatorParser GetMultiplyAndDivideParser(IParser next)
        {
            return new BinaryOperatorParser(new Dictionary<char, BinaryOperatorFactory>
                {
                    { '*', (l, r) => new MultiplicationOperator(l, r) },
                    { '/', (l, r) => new DivisionOperator(l, r) },
                    { '%', (l, r) => new ModulusOperator(l, r) }
                },
                next);
        }

        private static BinaryOperatorParser GetAddAndSubtractParser(IParser next)
        {
            return new BinaryOperatorParser(new Dictionary<char, BinaryOperatorFactory>
            {
                { '+', (l, r) => new AdditionOperator(l, r) },
                { '-', (l, r) => new SubtractionOperator(l, r) }
            },
                                        next);
        }
    }
}
