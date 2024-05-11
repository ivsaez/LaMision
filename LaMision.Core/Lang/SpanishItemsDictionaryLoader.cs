using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishItemsDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("rinonera_name", "riñonera"),
            new Word("rinonera_description", "Es una pequeña riñonera con un estampado de camuflaje de tonos marrones. Solo tiene un compartimento cerrado con una cremallera."),

            new Word("tarjetaBlanca_name", "tarjeta blanca"),
            new Word("tarjetaBlanca_description", "Es una tarjeta de plástico de color blanco. Es completamente lisa, no hay ninguna inscripción."),

            new Word("fluorescenteSalita_name", "fluorescente"),
            new Word("fluorescenteSalita_description", "El fluorescente está justo en medio del techo. Emite una luz blanca titilante."),

            new Word("mesaSalita_name", "mesa"),
            new Word("mesaSalita_description", "Es una mesa metálica con forma rectangular. Mirándola bien no se sabe si es una mesa o algún tipo de camilla."),

            new Word("escotilla_name", "escotilla"),
            new Word("escotilla_description", "Es una escotilla enorme y metálica, con un diámetro aproximado de metro y medio."),

            new Word("puertaSalita_name", "puerta de la salita"),
            new Word("puertaSalita_description", "Es una puerta de color blanco con un enorme número 5 escrito en el medio. No ha ningún pomo o maneta visibles."),
        };
    }
}
