using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class NumberLiteralParser : IParser
    {
        public IExpression? Parse(InputReader input)
        {
            var token = ReadIntegerPart(input) + ReadFractionalPart(input);

            GuardIsNotOnlySignCharacter(input, token);
            return ParseToken(token);
        }

        private static string ReadIntegerPart(InputReader input)
        {
            var token = "";
            token += input.TakeIf('-', '+');
            token += input.TakeWhile(char.IsDigit);
            return token;
        }

        private static string ReadFractionalPart(InputReader input)
        {
            var token = "";
            if (input.NextIs('.'))
            {
                token += input.TakeIf('.');
                token += input.TakeWhile(char.IsDigit);
            }

            return token;
        }

        private static void GuardIsNotOnlySignCharacter(InputReader input, string token)
        {
            if (token == "+" || token == "-")
            {
                throw new BadInputFormat(input.Text, input.Index);
            }
        }

        private static IExpression? ParseToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                return new NumberLiteral(double.Parse(token));
            }

            return null;
        }
    }
}
