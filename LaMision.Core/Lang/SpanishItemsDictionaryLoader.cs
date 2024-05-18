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

            new Word("luzRoja_name", "luz"),
            new Word("luzRoja_description", "Es un bulbo ovalado que emite una constante luz de color rojo de muy poca intensidad, como si se tratara de una luz de emergencia."),

            new Word("taquilla_name", "taquilla"),
            new Word("taquilla_description", "Es una taquilla metálica de aproximadamente metro y medio de altura. Está casi al final del pasillo apoyada contra la pared."),

            new Word("trajePlastico_name", "traje de goma"),
            new Word("trajePlastico_description", "Es un traje de goma para todo el cuerpo, parecido a un traje de apicultor. Tiene un color verde caqui."),

            new Word("puertaPasillo_name", "puerta del pasillo"),
            new Word("puertaPasillo_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("mesaSalon_name", "mesa del salón"),
            new Word("mesaSalon_description", "Es una mesa de cámping plegable, con la superfície de plástico y las patas metálicas."),

            new Word("silla_name", "silla"),
            new Word("silla_description", "Es una plegable de color negro."),

            new Word("sofa_name", "sofa"),
            new Word("sofa_description", "Es un sofá de tres plazas de color marrón. El tejido parece imitación de cuero."),

            new Word("tarjetaAzul_name", "tarjeta azul"),
            new Word("tarjetaAzul_description", "Es una tarjeta de plástico de color azul. Es completamente lisa, no hay ninguna inscripción."),

            new Word("puertaDormitorio_name", "puerta de la pared oeste del salón"),
            new Word("puertaDormitorio_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("puertaLavabo_name", "puerta de la pared este del salón"),
            new Word("puertaLavabo_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("litera_name", "litera"),
            new Word("litera_description", "Es una endeble litera metálica para dos camas, donde los somieres son láminas de madera. En este momento no tiene los colochones."),

            new Word("mesita_name", "mesita"),
            new Word("mesita_description", "Es una mesita de noche de madera, con un cajón. Encima de la mesita no hay nada."),

            new Word("vater_name", "váter"),
            new Word("vater_description", "Es un váter redondo y amarillento por la suciedad, con la cisterna justo encima con una cadenilla colgando. No tiene tapa, y puedes ver que tampoco hay agua dentro."),

            new Word("lavadero_name", "lavadero"),
            new Word("lavadero_description", "El lavadero es grande y cuadrado. Tiene un grifo monomando."),

            new Word("espejo_name", "espejo"),
            new Word("espejo_description", "Al mirarte al espejo ves la cara de un desconocido iluminada por la luz roja. Eres un hombre de unos 30 años, con la tez morena y el pelo completamente rasurado. Estás extremadamente delgado, con pómulos y sienes marcados, y con los dientes ennegrecidos."),

            new Word("tarjetaNaranja_name", "tarjeta naranja"),
            new Word("tarjetaNaranja_description", "Es una tarjeta de plástico de color naranja. Es completamente lisa, no hay ninguna inscripción."),

            new Word("armario_name", "armario"),
            new Word("armario_description", "Es un armario de madera. Parece ser algún tipo de despensa."),

            new Word("frasco_name", "frasco"),
            new Word("frasco_description", "Es un bote de plástico transparente que en algún momento pasado contuvo alguna conserva. Ahora está medio lleno de un aceite que desprende un olor nauseabundo."),
        };
    }
}
