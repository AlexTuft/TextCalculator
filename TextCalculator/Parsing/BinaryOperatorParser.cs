using System.Collections.Generic;
using System.Linq;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal delegate IExpression BinaryOperatorFactory(IExpression left, IExpression right);

    internal class BinaryOperatorParser : IParser
    {
        private readonly IDictionary<char, BinaryOperatorFactory> _supportedOperators;
        private readonly IParser _next;

        internal BinaryOperatorParser(IDictionary<char, BinaryOperatorFactory> supportedOperators, IParser next)
        {
            _supportedOperators = supportedOperators;
            _next = next;
        }

        public IExpression? Parse(InputReader input)
        {
            var left = ParseNextExpression(input);

            while (input.NextIs(_supportedOperators.Keys.ToArray()))
            {
                var symbol = input.Next();
                var right = ParseNextExpression(input);
                left = _supportedOperators[symbol]?.Invoke(left, right);
            }

            return left;
        }

        private IExpression ParseNextExpression(InputReader input)
        {
            var expression = _next.Parse(input);

            if (expression is null)
            {
                throw new BadInputFormat(input.Text, input.Index);
            }

            return expression;
        }
    }
}
