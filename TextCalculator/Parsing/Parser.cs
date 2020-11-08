using System;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        public IExpression? Parse(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return null;
            }

            var input = new InputReader(inputText);
            
            var expression = TryParseAdditionAndSubtraction(input);

            if (input.HasNext())
            {
                throw new BadInputFormat(input.Text, input.Index);
            }

            return expression;
        }

        private IExpression? TryParseAdditionAndSubtraction(InputReader input)
        {
            var left = TryParseMultiplication(input);

            if (left is null)
            {
                throw new BadInputFormat(input.Text, input.Index);
            }

            while (input.NextIs('+', '-'))
            {
                var c = input.Next();
                var right = TryParseMultiplication(input);

                if (right is null)
                {
                    throw new BadInputFormat(input.Text, input.Index);
                }

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

        private IExpression? TryParseMultiplication(InputReader input)
        {
            var left = TryParseNumberLiteral(input);

            if (left is null)
            {
                throw new BadInputFormat(input.Text, input.Index);
            }

            while (input.NextIs('*', '/'))
            {
                var c = input.Next();
                var right = TryParseNumberLiteral(input);

                if (right is null)
                {
                    throw new BadInputFormat(input.Text, input.Index);
                }

                if (c == '*')
                {
                    left = new MultiplicationOperator(left, right);
                }
                else
                {
                    left = new DivisionOperator(left, right);
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

            if (token == "+" || token == "-")
            {
                throw new BadInputFormat(input.Text, input.Index);
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
