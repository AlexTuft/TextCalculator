using System;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class GroupingParser : IParser
    {
        private readonly char _beginSymbol;
        private readonly char _endSymbol;
        private readonly Func<IExpression?, IExpression?> _expressionFactory;
        private readonly IParser _next;

        internal GroupingParser(char beginSymbol, char endSymbol, Func<IExpression?, IExpression?> expressionFactory, IParser next)
        {
            _beginSymbol = beginSymbol;
            _endSymbol = endSymbol;
            _expressionFactory = expressionFactory;
            _next = next;
        }

        internal IParser Start { get; set; } = new NullParser();

        public IExpression? Parse(InputReader input)
        {
            if (input.NextIs(_beginSymbol))
            {
                input.Next();
                var expression = Start.Parse(input);

                if (!input.NextIs(_endSymbol))
                {
                    throw new BadInputFormat(input.Text, input.Index);
                }
                input.Next();

                return _expressionFactory.Invoke(expression);
            }

            return _next.Parse(input);
        }
    }
}
