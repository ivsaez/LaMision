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
            new Word("salita_description", "La salita es una habitación cuadrada y pequeña, iluminada por tan solo un fluorescente de color blanco, como de hospital. Pegada a una pared hay una mesa. En otra de las paredes hay lo que parece una enorme escotilla redonda. En el lado opuesto a la escotilla hay una puerta. También ves algo más, un extraño dispositivo en el techo que no logras identificar."),

            new Word("pasillo_name", "pasillo"),
            new Word("pasillo_description", "Estás en un pasillo largo y estrecho. A medio camino hay un par de escalones y al fondo puedes ver otra puerta. Justo antes de la puerta hay una taquilla apoyada contra la pared. La única iluminación proviene de una lámpara de luz roja que hay encima de la puerta del fondo. El pasillo también dispone del extraño dispositivo en el techo."),
            new Word("pasillo_view", "Al otro lado ves un oscuro pasillo."),

            new Word("salon_name", "salón"),
            new Word("salon_description", "El salón es una estancia amplia con paredes, techo y suelo de hormigón visto. En medio hay una mesa con una silla y junto a la pared hay un sofá. Una luz roja mortecina es lo único que ilumina la habitación, dándole un aspecto lúgubre y abandonado. Además de la puerta del pasillo, en la pared oeste del salón hay una puerta y en la pared del lado opuesto hay otra. En el techo ves también el dispositivo del altavoz con el lez encendido."),
            new Word("salon_view", "Al otro lado se ve una sala más amplia, una especie de salón. Sientes una oleada de calor muy fuerte proveniente de esa sala, como si hubieras abierto la puerta de un horno."),

            new Word("dormitorio_name", "dormitorio"),
            new Word("dormitorio_description", "."),
            new Word("dormitorio_view", "Al otro lado ves lo que parece ser un dormitorio."),

            new Word("lavabo_name", "lavabo"),
            new Word("lavabo_description", "."),
            new Word("lavabo_view", "Al otro lado hay un lavabo."),
        };
    }
}
