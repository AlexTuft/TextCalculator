using System.Collections.Generic;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        private readonly IParser _parser;

        public Parser()
        {
            _parser = new BinaryOperatorParser(new Dictionary<char, BinaryOperatorFactory>
                {
                    { '+', (l, r) => new AdditionOperator(l, r) },
                    { '-', (l, r) => new SubtractionOperator(l, r) }
                },
                new BinaryOperatorParser(new Dictionary<char, BinaryOperatorFactory>
                    {
                        { '*', (l, r) => new MultiplicationOperator(l, r) },
                        { '/', (l, r) => new DivisionOperator(l, r) }
                    },
                    new NumberLiteralParser()));
        }

        public IExpression? Parse(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return null;
            }

            var input = new InputReader(inputText);

            var expression = _parser.Parse(input);

            if (input.HasNext())
            {
                throw new BadInputFormat(input.Text, input.Index);
            }

            return expression;
        }       
    }
}
