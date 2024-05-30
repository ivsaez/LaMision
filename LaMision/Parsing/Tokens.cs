using LaMision.Extensions;

namespace LaMision.Parsing
{
    public class Tokens
    {
        private readonly ISet<string> tokens;

        public Tokens(string sentence)
        {
            tokens = new HashSet<string>(sentence
                .Simplify()
                .Split(' ')
                .RemoveEmpty()
                .RemoveNonImportantWords());
        }

        public bool HasIncluded(Tokens other) =>
            other.tokens
                .All(inputToken => tokens
                    .Any(sentenceToken => 
                    {
                        if (inputToken.Length < 2)
                            return false;
                        else if (inputToken.Length == 2)
                            return sentenceToken == inputToken;
                        else
                            return sentenceToken == inputToken || sentenceToken.Contains(inputToken);
                    }));

        public override string ToString() =>
            $"[{string.Join(" ", tokens)}]";
    }
}
