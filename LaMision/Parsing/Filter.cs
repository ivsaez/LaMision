namespace LaMision.Parsing
{
    public class Filter(string sentence)
    {
        public bool Matches(string input)
        {
            if(string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return false;

            var sentenceTokens = new Tokens(sentence);
            var inputTokens = new Tokens(input);

            Console.WriteLine(sentenceTokens);
            Console.WriteLine(inputTokens);

            return sentenceTokens.HasIncluded(inputTokens);
        }
    }
}
