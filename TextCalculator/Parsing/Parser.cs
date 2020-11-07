using System;
using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        public IExpression? Parse(string input)
        {
            string token = "";

            bool parsingFraction = false;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '.')
                {
                    if (!parsingFraction)
                    {
                        parsingFraction = true;
                        token += c;
                    }
                    else
                    {
                        throw new BadInputFormat(input, i);
                    }
                }
                else if (char.IsDigit(c))
                {
                    token += c;
                }
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
