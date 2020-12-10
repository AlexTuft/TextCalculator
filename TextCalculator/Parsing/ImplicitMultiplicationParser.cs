using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class ImplicitMultiplicationParser : IParser
    {
        internal delegate bool Condition(InputReader input);

        private readonly IParser _next;

        internal ImplicitMultiplicationParser(IParser next)
        {
            _next = next;
        }

        public IExpression? Parse(InputReader input)
        {
            var expression = _next.Parse(input);

            while (input.NextIs('(', '|', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'))
            {
                var rightExpression = _next.Parse(input);

                if (expression is NumberLiteral && rightExpression is NumberLiteral)
                {
                    return null;
                }

                expression = new MultiplicationOperator(expression, rightExpression);
            }

            return expression;
        }
    }
}