using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishMappedsDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("radio_name", "radio"),
            new Word("radio_description", "Es la radio."),

            new Word("salita_name", "salita"),
            new Word("salita_description", "La salita es una habitación cuadrada y pequeña, iluminada por tan solo un fluorescente de color blanco, como de hospital. Pegada a una pared hay una mesa. En otra de las paredes hay lo que parece una enorme escotilla redonda. En el lado opuesto a la escotilla hay una puerta."),
        };
    }
}
