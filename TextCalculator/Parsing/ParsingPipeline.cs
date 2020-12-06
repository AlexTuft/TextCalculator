﻿using System.Collections.Generic;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal static class ParsingPipeline
    {
        internal static IParser Create()
        {
            // Declare in order of preceedence
            var numberLiteralParser = new NumberLiteralParser();
            var powerParser = GetPowerParser(numberLiteralParser);
            var multiplyAndDivideParser = GetMultiplyAndDivideParser(powerParser);
            var addAndSubtractParser = GetAddAndSubtractParser(multiplyAndDivideParser);

            return addAndSubtractParser;
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