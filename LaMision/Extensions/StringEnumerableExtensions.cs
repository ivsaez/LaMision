namespace LaMision.Extensions
{
    public static class StringEnumerableExtensions
    {
        private static readonly ISet<string> Articles = new HashSet<string>
        {
            "el",
            "la",
            "los",
            "las",
            "un",
            "uno",
            "una",
            "unos",
            "unas",
            "lo",
            "al",
            "del",
        };

        private static readonly ISet<string> Prepositions = new HashSet<string>
        {
            "a",
            "ante",
            "bajo",
            "cabe",
            "con",
            "contra",
            "de",
            "desde",
            "durante",
            "en",
            "entre",
            "hacia",
            "hasta",
            "mediante",
            "para",
            "por",
            "segun",
            "sin",
            "so",
            "sobre",
            "tras",
            "versus",
            "via",
        };

        public static IEnumerable<string> RemoveEmpty(this IEnumerable<string> list) =>
            list
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .ToList();

        public static IEnumerable<string> RemoveNonImportantWords(this IEnumerable<string> words) => 
            words
                .Where(word => !Articles.Contains(word) && !Prepositions.Contains(word))
                .ToList();
    }
}
