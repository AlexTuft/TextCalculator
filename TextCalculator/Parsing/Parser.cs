using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        public IExpression? Parse(string input)
        {
            string token = "";

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsDigit(c))
                {
                    token += c;
                }
            }

            if (!string.IsNullOrEmpty(token))
            {
                return new NumberLiteral(int.Parse(token));
            }

            return null;
        }
    }
}
