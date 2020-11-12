using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class ParenthesisParser : IParser
    {
        private readonly IParser _next;

        internal ParenthesisParser(IParser next)
        {
            _next = next;
        }

        internal IParser Start { get; set; } = new NullParser();

        public IExpression? Parse(InputReader input)
        {
            if (input.NextIs('('))
            {
                input.Next();
                var expression = Start.Parse(input);
                
                if (!input.NextIs(')'))
                {
                    throw new BadInputFormat(input.Text, input.Index);
                }
                input.Next();

                return expression;
            }

            return _next.Parse(input);
        }
    }
}
