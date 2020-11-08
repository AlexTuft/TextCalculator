using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    internal class NumberLiteralParser : IParser
    {
        public IExpression? Parse(InputReader input)
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
    }
}
