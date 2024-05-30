namespace LaMision.Parsing
{
    public class Filter(string sentence)
    {
        public bool Matches(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
                return false;

            var sentenceTokens = new Tokens(sentence);
            var inputTokens = new Tokens(input);

            return sentenceTokens.HasIncluded(inputTokens);
        }
    }
}
