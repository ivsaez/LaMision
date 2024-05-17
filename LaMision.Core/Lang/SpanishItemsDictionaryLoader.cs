using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishItemsDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("rinonera_name", "riñonera"),
            new Word("rinonera_description", "Es una pequeña riñonera con un estampado de camuflaje de tonos marrones. Solo tiene un compartimento cerrado con una cremallera."),

            new Word("dispositivo_name", "dispositivo"),
            new Word("dispositivo_description", "El dispositivo tiene forma rectangular y está incrustado en el techo. Se asemeja a un altavoz, pero también tiene una pequeña lente negra y un led rojo siempre encendido."),

            new Word("tarjetaBlanca_name", "tarjeta blanca"),
            new Word("tarjetaBlanca_description", "Es una tarjeta de plástico de color blanco. Es completamente lisa, no hay ninguna inscripción."),

            new Word("fluorescenteSalita_name", "fluorescente"),
            new Word("fluorescenteSalita_description", "El fluorescente está justo en medio del techo. Emite una luz blanca titilante."),

            new Word("mesaSalita_name", "mesa"),
            new Word("mesaSalita_description", "Es una mesa metálica con forma rectangular. Mirándola bien no se sabe si es una mesa o algún tipo de camilla."),

            new Word("escotilla_name", "escotilla"),
            new Word("escotilla_description", "Es una escotilla enorme y metálica, con un diámetro aproximado de metro y medio."),

            new Word("puertaSalita_name", "puerta de la salita"),
            new Word("puertaSalita_description", "Es una puerta de color blanco con un enorme número 5 escrito en el medio. No hay ningún pomo o maneta visibles."),

            new Word("luzPasillo_name", "luz"),
            new Word("luzPasillo_description", "Es un bulbo ovalado que emite una constante luz de color rojo de muy poca intensidad, como si se tratara de una luz de emergencia."),

            new Word("taquilla_name", "taquilla"),
            new Word("taquilla_description", "Es una taquilla metálica de aproximadamente metro y medio de altura. Está casi al final del pasillo apoyada contra la pared."),

            new Word("trajePlastico_name", "traje de goma"),
            new Word("trajePlastico_description", "Es un traje de goma para todo el cuerpo, parecido a un traje de apicultor. Tiene un color verde caqui."),

            new Word("puertaPasillo_name", "puerta del pasillo"),
            new Word("puertaPasillo_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),
        };
    }
}
