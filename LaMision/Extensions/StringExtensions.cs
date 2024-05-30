using System.Text;

namespace LaMision.Extensions
{
    public static class StringExtensions
    {
        private const string AccentedVowels = "áéíóúäëïöüâêîôûàèìòù";
        private const string RegularVowels = "aeiou";
        private const string SpecialCharacters = "ñç";
        private const string RegularCharacters = "nc";

        public static string Simplify(this string input)
        {
            string lowerInput = input.Trim().ToLower();

            var builder = new StringBuilder();
            for (int i = 0; i < lowerInput.Length; i++)
            {
                char c = lowerInput[i];

                int position = AccentedVowels.IndexOf(c);
                if (position >= 0)
                {
                    builder.Append(RegularVowels[position % 5]);
                }
                else
                {
                    position = SpecialCharacters.IndexOf(c);
                    if (position >= 0)
                    {
                        builder.Append(RegularCharacters[position]);
                    }
                }

                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == ' ')
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
