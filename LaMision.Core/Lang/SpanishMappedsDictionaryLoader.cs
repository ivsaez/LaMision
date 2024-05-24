using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishMappedsDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("nowhere_name", "nowhere"),
            new Word("nowhere_description", "Nowhere."),

            new Word("radio_name", "radio"),
            new Word("radio_description", "Es la radio."),

            new Word("salita_name", "salita"),
            new Word("salita_description", "La salita es una habitación cuadrada y pequeña, iluminada por tan solo un fluorescente de color blanco, como de hospital. Pegada a una pared hay una mesa. En otra de las paredes hay lo que parece una enorme escotilla redonda. En el lado opuesto a la escotilla hay una puerta. También ves algo más, un extraño dispositivo en el techo que no logras identificar."),

            new Word("pasillo_name", "pasillo"),
            new Word("pasillo_description", "Estás en un pasillo largo y estrecho. A medio camino hay un par de escalones y al fondo puedes ver otra puerta. Justo antes de la puerta hay una taquilla apoyada contra la pared. La única iluminación proviene de una lámpara de luz roja que hay encima de la puerta del fondo. El pasillo también dispone del extraño dispositivo en el techo."),
            new Word("pasillo_view", "Al otro lado ves un oscuro pasillo."),

            new Word("salon_name", "salón"),
            new Word("salon_description", "El salón es una estancia amplia con paredes, techo y suelo de hormigón visto. En medio hay una mesa con una silla y junto a la pared hay un sofá. En la misma pared del sofá hay a un lado un armario y al otro una puerta de color naranja. Una luz roja mortecina es lo único que ilumina la habitación, dándole un aspecto lúgubre y abandonado. Además de la puerta del pasillo, en la pared oeste del salón hay una puerta y en la pared del lado opuesto hay otra. En el techo ves también el dispositivo del altavoz con el lez encendido."),
            new Word("salon_view", "Al otro lado se ve una sala más amplia, una especie de salón. Sientes una oleada de calor muy fuerte proveniente de esa sala, como si hubieras abierto la puerta de un horno."),

            new Word("dormitorio_name", "dormitorio"),
            new Word("dormitorio_description", "El dormitorio es una habitación muy pequeña, iluminada por otra luz roja. Dos de las paredes son de hormigón visto, mientras que la pared del fondo tiene un empapelado a cuadros blancos y verdes. Los únicos muebles son una litera y una mesita."),
            new Word("dormitorio_view", "Al otro lado ves lo que parece ser un dormitorio."),

            new Word("lavabo_name", "lavabo"),
            new Word("lavabo_description", "El lavabo es pequeño y está iluminado por una luz roja situada encima de la puerta. Únicamente consta de un váter y un lavadero. En la pared de hormigón visto hay colgado un espejo rectangular."),
            new Word("lavabo_view", "Al otro lado hay un lavabo."),

            new Word("salaBoton_name", "sala del botón"),
            new Word("salaBoton_description", "Es una sala muy pequeña y cuadrada, con las paredes de hormigón visto e iluminada por una luz roja situada encima de la entrada. No hay nada salvo un pedestal en medio de la sala, coronado por un enorme botón rojo. Al lado oeste hay otro cuarto abierto donde se ve la sala de controles. En el techo ves de nuevo el dispositivo del altavoz, justo en medio de la sala del botón y de los controles."),
            new Word("salaBoton_view", "Al otro lado ves una pequeña sala donde se encuentra el botón. De esa sala emana un calor aún más sofocante que en el salón."),

            new Word("salaControl_name", "sala de control"),
            new Word("salaControl_description", "Más que una sala parece un armario grande, iluminado por un bulbo de color rojo en el techo. En el techo hay un dispositivo con altavoz, justo en medio de la sala del botón y de los controles."),

            new Word("otroLavabo_name", "lavabo"),
            new Word("otroLavabo_description", "Estás en un lavabo. Es pequeño y está iluminado por una luz roja situada encima de la puerta. Únicamente consta de un váter y un lavadero. En la pared de hormigón visto hay colgado un espejo rectangular. El hueco de la rejilla por donde has entrado queda justo al lado del váter. Tiene una puerta abierta y puedes ver a través de ella un salón grande."),

            new Word("otroSalon_name", "salón"),
            new Word("otroSalon_description", "El salón es idéntico al otro a excepción de la puerta naranja, que aquí es rosa. La luz está en el mismo sitio, también el dispositivo. Tiene prácticamente el mismo mobiliario pero alguien lo ha destrozado todo."),

            new Word("otroPasillo_name", "pasillo"),
            new Word("otroPasillo_description", "Estás en un pasillo largo y estrecho. A medio camino hay un par de escalones y al fondo puedes ver otra puerta con un número. Volcada en el suelo hay una taquilla. La única iluminación proviene de una lámpara de luz roja que hay encima de la puerta del fondo. El pasillo también dispone del extraño dispositivo en el techo."),
        };
    }
}
