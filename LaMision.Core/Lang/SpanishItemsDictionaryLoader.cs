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

            new Word("sofa_name", "sofá"),
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

            new Word("puertaNaranja_name", "puerta naranja"),
            new Word("puertaNaranja_description", "Es una puerta de color naranja, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("boton_name", "botón"),
            new Word("boton_description", "El botón se encuentra encima de un pedestal metálico. Es un botón rojo y enorme, como los que salen en los concursos de preguntas en televisión. Uno esperaría que estuviera encendido por dentro con una luz roja, pero seguramente no lo está porque falta arreglar la conexión."),

            new Word("pared_name", "pared"),
            new Word("pared_description", "Una de las paredes de la habitación tiene un horrible empapelado a cuadros verdes y blancos. El papel está cuarteado por el terrible calor que hace en este lugar."),
            new Word("pared_text_1", "Oyes unos pasos al otro lado de la pared."),
            new Word("pared_text_2", "Algo ha golpeado la pared desde el otro lado."),
            new Word("pared_text_3", "Se oye un golpe fuerte al otro lado, como de alguien cayendo al suelo."),
            new Word("pared_text_4", "Te parece oir una voz al otro lado de la pared, como un grito."),

            new Word("rejilla_name", "rejilla"),
            new Word("rejilla_description", "La rejilla es metálica pero muy fina, parecida a la reja de un colador. Cubre lo que parece ser un conducto de aire rectangular. Está completamente rota, quizá una persona menuda o muy delgada podría caber por ese conducto."),

            new Word("cableNegro_name", "cable negro"),
            new Word("cableNegro_description", "Es un cable de color negro."),

            new Word("cableBlanco_name", "cable blanco"),
            new Word("cableBlanco_description", "Es un cable de color blanco."),

            new Word("cableGris_name", "cable gris"),
            new Word("cableGris_description", "Es un cable de color gris."),

            new Word("cableAzul_name", "cable azul"),
            new Word("cableAzul_description", "Es un cable de color azul."),

            new Word("cableRojo_name", "cable rojo"),
            new Word("cableRojo_description", "Es un cable de color rojo."),

            new Word("cableAmarillo_name", "cable amarillo"),
            new Word("cableAmarillo_description", "Es un cable de color amarillo."),

            new Word("interruptor1_name", "interruptor 1"),
            new Word("interruptor1_description", "Es un interruptor con el número 1."),

            new Word("interruptor2_name", "interruptor 2"),
            new Word("interruptor2_description", "Es un interruptor con el número 2."),

            new Word("interruptor3_name", "interruptor 3"),
            new Word("interruptor3_description", "Es un interruptor con el número 3."),

            new Word("interruptor4_name", "interruptor 4"),
            new Word("interruptor4_description", "Es un interruptor con el número 4."),

            new Word("interruptor5_name", "interruptor 5"),
            new Word("interruptor5_description", "Es un interruptor con el número 5."),

            new Word("interruptor6_name", "interruptor 6"),
            new Word("interruptor6_description", "Es un interruptor con el número 6."),

            new Word("interruptor7_name", "interruptor 7"),
            new Word("interruptor7_description", "Es un interruptor con el número 7."),

            new Word("interruptor8_name", "interruptor 8"),
            new Word("interruptor8_description", "Es un interruptor con el número 8."),

            new Word("interruptor9_name", "interruptor 9"),
            new Word("interruptor9_description", "Es un interruptor con el número 9."),

            new Word("interruptor10_name", "interruptor 10"),
            new Word("interruptor10_description", "Es un interruptor con el número 10."),

            new Word("palanca_name", "palanca"),
            new Word("palanca_description", "Es una palanca parecida a la de las máquinas tragaperras."),

            new Word("hueco_name", "hueco"),
            new Word("hueco_description", "Es el hueco por donde te has colado desde el dormitorio. Sigue manchado de aceite por lo que seguramente puedes volver a pasar."),

            new Word("tarjetaInexistente_name", "tarjeta inexistente"),
            new Word("tarjetaInexistente_description", "No existe."),

            new Word("otraPuertaLavabo_name", "puerta de la pared este del salón"),
            new Word("otraPuertaLavabo_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("otraMesaSalon_name", "mesa"),
            new Word("otraMesaSalon_description", "Era una mesa plegable, pero ahora tiene las patas doblegadas y la superfície rota."),

            new Word("otroSofa_name", "sofá"),
            new Word("otroSofa_description", "Es un sofá de imitación de piel de color marrón. Está volcado en el suelo y alguien le ha rajado los cojines."),

            new Word("otroArmario_name", "armario"),
            new Word("otroArmario_description", "Es un armario de madera, tipo despensa."),

            new Word("otraPuertaDormitorio_name", "puerta de la pared oeste del salón"),
            new Word("otraPuertaDormitorio_description", "Es una puerta de color gris, completamente lisa. No hay ningún pomo o maneta visibles."),

            new Word("puertaRosa_name", "puerta rosa"),
            new Word("puertaRosa_description", "Es una puerta de color rosa, completamente lisa. No hay ningún pomo o maneta visibles."),
        };
    }
}
