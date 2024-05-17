using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("initial_1", "Abres los ojos con dificultad entreviendo una débil luz blanca. Te das cuenta de que estás tumbado en el suelo boca arriba, con los brazos estirados."),
            new Word("initial_2", "¿Estabas durmiendo? ¿Te habías desmayado?"),
            new Word("initial_3", "Notas la boca seca y una ligera sensación de mareo, por lo demás estás bien."),

            new Word("mirar_mapped_1_interaction_description", "Mirar el lugar donde te encuentras"),

            new Word("mirar_item_1_interaction_description", "Mirar {thing}"),

            new Word("coger_1_interaction_description", "Coger {thing}"),
            new Word("coger_good", "Coges y guardas {1}."),
            new Word("coger_big", "No puedes coger {1} porque es demasiado grande."),
            new Word("coger_heavy", "No puedes coger {1} porque pesa demasiado."),
            new Word("coger_nobag", "No puedea coger {1} porque no tienes donde guardar cosas."),

            new Word("dejar_1_interaction_description", "Dejar {thing}"),
            new Word("dejar", "Dejas {1} en el suelo."),

            new Word("ir_1_interaction_description", "Ir hacia hacia {place}"),
            new Word("ir", "Te desplazas hacia {1}."),
            new Word("ir_door", "No puedes ir hacia {1} sin antes abrir la puerta."),

            new Word("abrir_1_interaction_description", "Abrir {openable}"),
            new Word("abrir_text", "Te dispones a abrir {0}."),
            new Word("abrir_invalidKey", "Parece ser que {0} no sirve para abrir {1}."),
            new Word("abrir_sucess", "Abres {0} sin problema."),

            new Word("cerrar_1_interaction_description", "Cerrar {openable}"),
            new Word("cerrar_text", "Cierras {0}."),

            new Word("mensajeLevanta_1_interaction_description", "Suena una locución"),
            new Word("mensajeLevanta_text_1", "Se oye un mensaje por toda la sala proveniente de una voz masculina algo distorsionada."),
            new Word("mensajeLevanta_text_2", "La voz retumba de nuevo, algo menos distorsionada."),
            new Word("mensajeLevanta_voz_1", "Le habla el comandante Hoffmann. Tiene que levantarse. Recuerde la misión."),
            new Word("mensajeLevanta_voz_2", "Al habla el comandante Hoffmann. Levante del suelo recluta Kazinsky."),
            new Word("mensajeLevanta_voz_3", "Comandante Hoffmann al habla. Tiene que levantarse."),
            new Word("mensajeLevanta_voz_4", "Le habla el comandante Hoffmann. ¡Arriba recluta!."),
            new Word("mensajeLevanta_voz_5", "Al habla el comandante Hoffmann. La misión aguarda, debe levantarse inmediatamente."),

            new Word("levantarse_1_interaction_description", "Levantarte"),
            new Word("levantarse_text", "Te levantas del suelo y te pones de pie."),

            new Word("agacharse_1_interaction_description", "Agacharte"),
            new Word("agacharse_text", "Te agachas apoyando una rodilla en el suelo."),

            new Word("tumbarse_1_interaction_description", "Tumbarte"),
            new Word("tumbarse_text", "Te tumbas en el suelo."),

            new Word("abrirEscotilla_1_interaction_description", "Abrir {thing}"),
            new Word("abrirEscotilla_text", "Intentas abrir la escotilla pero enseguida te das cuenta de que no es posible. No hay ningun asidero para poder estirar, es completamente lisa. Además parece extremadamente pesada. Seguramente se abre con algún sistema mecánico."),

            new Word("acercarTarjetaPuerta_1_interaction_description", "Acercar {tarjeta} a {door}"),
            new Word("acercarTarjetaPuerta_text", "Acercas {0} a {1}."),
            new Word("acercarTarjetaPuerta_invalidKey", "Parece ser que esa tarjeta no funciona con esta puerta."),
            new Word("acercarTarjetaPuerta_sucess_1", "La puerta se abre de forma automática lateralmente."),
            new Word("acercarTarjetaPuerta_sucess_2", "Se oye el ruido de un motor en la pared y la puerta se abre lateralmente."),
            new Word("acercarTarjetaPuerta_sucess_3", "La puerta se abre en un rápido movimiento lateral."),

            new Word("mision_1_interaction_description", "La misión"),
            new Word("mision_text", "Se oye una voz potente desde el altavoz."),
            new Word("mision_text_1", "¡Kazinsky! ¡Recompóngase! No queda nadie mas en pie. El éxito de la misión depende de usted."),
            new Word("mision_text_2", "La misión... claro, la misión. ¿Quién... quién es usted? ¿Por dónde me habla?"),
            new Word("mision_text_3", "Le habla el comandante Hoffmann. Estoy aquí para ayudarle Kazinsky, pero debe actuar ya."),
            new Word("mision_text_4", "El comandante. Claro, el comandante. No recuerdo nada comandante. No recuerdo la misión..."),
            new Word("mision_text_5", "Está usted en el búnker del alto mando, que se encuentra ahora mismo bajo intenso fuego enemigo."),
            new Word("mision_text_6", "El enemigo, claro. ¿Vienen a por mi?"),
            new Word("mision_text_7", "Kazinsky, debe usted apretar el boton de ignición. Es vital para la misión que lo haga antes de que el enemigo tome el búnker."),
            new Word("mision_text_8", "El botón, sí claro. Debo pulsarlo."),
            new Word("mision_text_9", "Ahora mismo el mecanismo de ignición tiene el soporte de energía cortado. Debe usted arreglar la conexión primero, y luego pulsar el botón. ¿Ha entendido?"),
            new Word("mision_text_10", "Entendido comandante. Arreglar la conexión y pulsar el botón."),
            new Word("mision_text_11", "Adelante Kazinsky, confiamos en usted."),

            new Word("mensajePasillo_1_interaction_description", "Suena una locución"),
            new Word("mensajePasillo_text_1", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("mensajePasillo_voz_1", "Avance por el pasillo. No se detenga."),
            new Word("mensajePasillo_voz_2", "¡Muévase Kazinsky! No hay tiempo."),
            new Word("mensajePasillo_voz_3", "No se entretenga en el pasillo. Muévase."),
            new Word("mensajePasillo_voz_4", "No se detenga en el pasillo, el enemigo está cerca."),

            new Word("cogerTraje_1_interaction_description", "Coger {thing}"),
            new Word("cogerTraje_text", "Intentas coger el traje, pero el plástico está algo deshecho por el calor. Si intentas tirar de él se romperá. De repente caes en la cuenta de que hace mucho calor en el pasillo."),

            new Word("mensajeLevanta2_1_interaction_description", "Suena una locución"),
            new Word("mensajeLevanta2_text_1", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("mensajeLevanta2_voz_1", "No es momento de descansar recluta."),
            new Word("mensajeLevanta2_voz_2", "No se duerma ahora Kazinsky. Recuerde la misión."),
            new Word("mensajeLevanta2_voz_3", "¡Arriba! ¡Levante!"),
            new Word("mensajeLevanta2_voz_4", "¡Muévase Kazinsky! No hay tiempo para descansar."),

            //new Word("saludo_1_interaction_description", "{main} saluda a {saluted}."),
            //new Word("saludo_11_interaction_description", "{saluted} saluda a {main}."),
            //new Word("saludo_text", "Buenas {0}."),
            //new Word("respuesta_text", "Hola {0}."),

            //new Word("pedirse_1_interaction_description", "{main} se tira un cuesco."),
            //new Word("pedirse_text", "{0} levanta la pierna y se tira un sonoro pedo."),
            //new Word("pedirse_conversation", "¡Ups! Perdón."),

            //new Word("sacamoco_1_interaction_description", "{main} se saca una burilla."),
            //new Word("sacamoco_text", "{0} se saca una burilla, hace una pelotilla y la proyecta contra el suelo con los dedos."),

            //new Word("estornudo_1_interaction_description", "{main} estornuda."),
            //new Word("estornudo_1_text", "{0} estornuda sonoramente."),
            //new Word("estornudo_11_interaction_description", "{main} se limpia con la manga izquierda."),
            //new Word("estornudo_2_text", "{0} se limpia la nariz con el dorso de la manga izquierda."),
            //new Word("estornudo_12_interaction_description", "{main} se limpia con la manga derecha."),
            //new Word("estornudo_3_text", "{0} se limpia la nariz con el dorso de la manga derecha."),
        };
    }
}
