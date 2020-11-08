using System;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        public IExpression? Parse(string inputText)
        {
            var input = new InputReader(inputText);
            return TryParseAdditionAndSubtraction(input);
        }

        private IExpression? TryParseAdditionAndSubtraction(InputReader input)
        {
            var left = TryParseNumberLiteral(input);

            while (input.NextIs('+', '-'))
            {
                var c = input.Next();
                var right = TryParseNumberLiteral(input);

                if (c == '+')
                {
                    left = new AdditionOperator(left, right);
                }
                else
                {
                    left = new SubtractionOperator(left, right);
                }
            }

            return left;
        }

        private IExpression? TryParseNumberLiteral(InputReader input)
        {
            string token = "";

            token += input.TakeIf('-', '+');
            token += input.TakeWhile(char.IsDigit);

            if (input.NextIs('.'))
            {
                token += input.TakeIf('.');
                token += input.TakeWhile(char.IsDigit);
            }

            if (!string.IsNullOrEmpty(token))
            {
                return new NumberLiteral(double.Parse(token));
            }

            return null;
        }

        public class BadInputFormat : Exception
        {
            public BadInputFormat(string input, int index) : base(CreateMessage(input, index))
            {
            }

            private static string CreateMessage(string input, int index)
            {
                return $"Could not parse input at index {index}\n" +
                    input + '\n' +
                    new string(' ', index) + "^\n";
            }
        }
    }
}
