namespace TextCalculator.Parsing
{
    internal class InputReader
    {
        internal InputReader(string text)
        {
            Text = text;
            Index = 0;
        }

        internal string Text { get; }

        internal int Index { get; private set; }

        internal bool HasNext()
        {
            return Index < Text.Length;
        }

        internal char Next()
        {
            return Text[Index++];
        }
    }
}
