using System;
using TextCalculator.Parsing;

namespace TextCalculatorRepl
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            while (true)
            {
                var input = GetInput();

                try
                {
                    EvaluateAndPrintResult(parser, input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string GetInput()
        {
            Console.Write('>');
            var input = Console.ReadLine();
            return input;
        }

        private static void EvaluateAndPrintResult(Parser parser, string input)
        {
            var expression = parser.Parse(input);

            if (expression != null)
            {
                Console.WriteLine(expression.Result);
            }
        }
    }
}
