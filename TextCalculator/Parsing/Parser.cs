using TextCalculator.Expressions;

namespace TextCalculator.Parsing
{
    public class Parser
    {
        private readonly IParser _parser;

        public Parser()
        {
            _parser = ParsingPipeline.Create();
        }

        public IExpression? Parse(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return null;
            }

            return ParseInput(inputText);
        }

        private IExpression? ParseInput(string inputText)
        {
            var input = new InputReader(inputText);
            var expression = _parser.Parse(input);

            GuardHasParsedWholeInput(input);

            return expression;
        }

        private static void GuardHasParsedWholeInput(InputReader input)
        {
            if (input.HasNext())
            {
                throw new BadInputFormat(input.Text, input.Index);
            }
        }
    }
}
