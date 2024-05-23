﻿using Languager;

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

            new Word("empujar_1_interaction_description", "Empujar {thing}"),
            new Word("empujar", "Intentas empujar {0} pero pesa demasiado."),

            new Word("coger_1_interaction_description", "Coger {thing}"),
            new Word("coger_good", "Coges y guardas {1}."),
            new Word("coger_big", "No puedes coger {1} porque es demasiado grande."),
            new Word("coger_heavy", "No puedes coger {1} porque pesa demasiado."),
            new Word("coger_nobag", "No puedea coger {1} porque no tienes donde guardar cosas."),

            new Word("dejar_1_interaction_description", "Dejar {thing}"),
            new Word("dejar", "Dejas {0} en el suelo."),

            new Word("dejarEn_1_interaction_description", "Dejar {thing} dentro de {recipient}"),
            new Word("dejarEn_closed", "Hay que abrir {0} para poder poner cosas dentro."),
            new Word("dejarEn_big", "No se puede poner {0} dentro de {1}. Es demasiado grande."),
            new Word("dejarEn_heavy", "No se puede poner {0} dentro de {1}. Pesa demasiado."),
            new Word("dejarEn_success", "Dejas {0} en {1}."),

            new Word("ir_1_interaction_description", "Ir hacia hacia {place}"),
            new Word("ir", "Te desplazas hacia {1}."),
            new Word("ir_door", "No puedes ir hacia {1} sin antes abrir la puerta."),

            new Word("ir_reptando_1_interaction_description", "Ir reptando hacia hacia {place}"),
            new Word("ir_reptando", "Te desplazas reptando hacia {1}."),

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

            new Word("sentarSofa_1_interaction_description", "Sentarte en el sofá"),
            new Word("sentarSofa_text", "Tocas el sofá antes de sentarte... está ardiendo. Prefieres quedarte de pie."),

            new Word("usarVater_1_interaction_description", "Usar el váter"),
            new Word("usarVater_text", "Te sientas en el sucio váter y aprietas el vientre. Estás completamente vacío, nada en el intestino y nada en la vejiga. Lo único que sale es un sonoro pedo que inunda la estancia de un nauseabundo olor durante unos segundos."),

            new Word("usarLavadero_1_interaction_description", "Abrir el grifo del lavadero"),
            new Word("usarLavadero_text", "Levantas el grifo monomando pero no sucede nada. No cae ni una gota, el agua debe estar cortada desde hace tiempo."),

            new Word("usarLitera_1_interaction_description", "Tumbarte en la litera"),
            new Word("usarLitera_text", "Palpas la lámina de madera que hace las funciones de somier. Está fría y dura, sería lo mismo que tumbarte en el suelo."),

            new Word("beberFrasco_1_interaction_description", "Beber el aceite del frasco"),
            new Word("beberFrasco_text", "Acercas el frasco a la boca y un olor a pescado muerto te llena la nariz. Desistes de la idea de tragar ese aceite."),

            new Word("mensajeSalon_1_interaction_description", "Suena una locución"),
            new Word("mensajeSalon_text_1", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("mensajeSalon_voz_1", "Busque la manera de acceder a la sala de control."),
            new Word("mensajeSalon_voz_2", "La puerta naranja es el objetivo. Debe abrirla."),
            new Word("mensajeSalon_voz_3", "Diríjase a la sala de control Kazinsky."),
            new Word("mensajeSalon_voz_4", "Abra la puerta naranja Kazinsky. El éxito de la misión depende de ello."),
            new Word("mensajeSalon_voz_5", "Abra la puerta naranja. Utilice la tarjeta del mismo color."),
            new Word("mensajeSalon_voz_6", "Debe cruzar la puerta de color naranja. La tarjeta de acceso debe estar ahí en algún sitio."),
            new Word("mensajeSalon_voz_7", "No pierda tiempo recluta. Lo que busca está tras la puerta naranja."),
            new Word("mensajeSalon_voz_8", "¡Kazinsky! ¡A la puerta naranja!."),
            new Word("mensajeSalon_voz_9", "El enemigo se acerca recluta. Creo que no debo necesitar recordárselo."),
            new Word("mensajeSalon_voz_10", "Utilice las tarjetas de acceso. Puede que alguna se haya caído de su sitio. Busque y encuéntrelas todas."),

            new Word("mirarDebajoSofa_1_interaction_description", "Mirar debajo del sofá"),
            new Word("mirarDebajoSofa_text", "Debajo del sofá ya solo queda polvo."),
            new Word("mirarDebajoSofa_something_text", "Debajo del sofá hay algo. Parece una tarjeta de acceso, en este caso es la de color naranja."),

            new Word("cogerTarjetaNaranja_1_interaction_description", "Coger la tarjeta de debajo del sofá"),

            new Word("pulsarBoton_1_interaction_description", "Pulsar el botón"),
            new Word("pulsarBoton_text", "Pulsas el botón dándole un manotazo. No sucede nada."),

            new Word("cogerMesaPlegable_1_interaction_description", "Coget {thing}"),
            new Word("cogerMesaPlegable_text", "En condiciones normales no tendrías problemas en plegar la mesa y cargarla, pero en este momento te encuentras extremadamente débil."),

            new Word("mirarDebajoLitera_1_interaction_description", "Mirar debajo de la litera"),
            new Word("mirarDebajoLitera_text", "Debajo de la litera hay una rejilla. Está rota, de manera que ahora el conducto está libre."),
            new Word("mirarDebajoLitera_something_text", "Debajo de la litera hay una rejilla. La rejilla es metálica pero muy fina, parecida a la reja de un colador. Cubre lo que parece ser un conducto de aire rectangular. Quizá una persona menuda o muy delgada podría caber por ese conducto."),

            new Word("romperRejilla_1_interaction_description", "Romper la rejilla"),
            new Word("romperRejilla_text", "Golpeas la rejilla con el pie varias veces hasta que logras romperla del todo."),

            new Word("empujarLitera_1_interaction_description", "Empujar {thing}"),
            new Word("empujarLitera_text", "La litera está atornillada al suelo, no puedes moverla."),

            new Word("mensajeBoton_1_interaction_description", "Suena una locución"),
            new Word("mensajeBoton_text_1", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("mensajeBoton_voz_1", "Ya ha accedido a la sala del botón ¡Estamos muy cerca de conseguirlo!"),
            new Word("mensajeBoton_voz_2", "Debe activar la conexión recluta."),
            new Word("mensajeBoton_voz_3", "El botón no funciona Kazinsky. Primero hay que activar la conexión."),
            new Word("mensajeBoton_voz_4", "No es coplicado Kazinsky. Solo es un botón."),

            new Word("conexion_1_interaction_description", "Suena una locución"),
            new Word("conexion_text", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("conexion_text_1", "Kazinski, está usted muy cerca de terminar la misión con éxito."),
            new Word("conexion_text_2", "El enemigo, ¿como va el enemigo?"),
            new Word("conexion_text_3", "No piense ahora en el enemigo. Concéntrese en activar la conexión."),
            new Word("conexion_text_4", "¿Cómo lo hago? ¿Enchufo los cables y ya?"),
            new Word("conexion_text_5", "No se precipite Kazinsky, simplemente recuerde la instrucción."),
            new Word("conexion_text_6", "No lo recuerdo Comandante... no puedo recordar nada."),
            new Word("conexion_text_7", "Serénese Kazinsky. Yo le ayudaré. Gracias a su instrucción activar la conexión es un mero trámite."),
            new Word("conexion_text_8", "Ayúdeme por favor Comandante, no soy capaz de recordar nada."),
            new Word("conexion_text_9", "Delante suyo tiene un panel con 3 cables en el lazo izquierdo: uno negro, uno blanco y uno gris. En el lado derecho hay otros 3: uno rojo, uno azul y uno amarillo."),
            new Word("conexion_text_10", "Si sí, los veo."),
            new Word("conexion_text_11", "Tiene usted que conectar cada cable del panel izquierdo con uno del panel derecho. Es muy sencillo adivinar la combinación si recuerda su código regional."),
            new Word("conexion_text_12", "El código regional..."),
            new Word("conexion_text_13", "Eso no es todo. Hace falta poner la contraseña de seguridad. Encima del panel hay 10 interruptores numerados del 1 al 10. Cada interruptor puede estar pulsado o no. Simplemente debe pulsar los interruptores correspondientes a la contraseña."),
            new Word("conexion_text_14", "La contraseña. No conozco ninguna contraseña."),
            new Word("conexion_text_15", "La conoce sin duda. Además yo puedo facilitarle trucos pnemotécnicos de la instrucción para ayudarle a recordar."),
            new Word("conexion_text_16", "Gracias Comandante. Voy a necesitar su ayuda."),
            new Word("conexion_text_17", "Una cosa mas Kazinsky. Cuando considere que ha conectado los cables y pulsado los botones adecuados, tire de la palanca lateral. Si todo es correcto el botón se activará."),
            new Word("conexion_text_18", "Así lo haré Comandante."),

            new Word("pistas_1_interaction_description", "Suena una locución"),
            new Word("pistas_text_1", "Suena la voz del Comandante por el altavoz del dispositivo."),
            new Word("pistas_voz_1", "Recuerde su región de entrenamiento. Ahí está la clave de los colores."),
            new Word("pistas_voz_2", "La contraseña es cíclica. Su base parte de la hora actual."),
            new Word("pistas_voz_3", "Los pulsadores actúan como una secuencia binária. Piénselo Kazinsky, es todo más sencillo de lo que parece."),
            new Word("pistas_voz_4", "No se ponga nervioso Kazinsky. Es mucho mas simple de lo que aparenta. Tiene usted la instrucción suficiente para resolverlo."),
            new Word("pistas_voz_5", "Los decimales del número Pi son importantes. Hay dos en posiciones muy icónicas que son fundamentales aquí."),
            new Word("pistas_voz_6", "Ha visto usted un número en una de las puertas. Téngalo en cuenta para la contraseña."),
            new Word("pistas_voz_7", "Son tres cables en tonos de gris y tres en color. Si lo piensa, tiene mucho sentido."),
            new Word("pistas_voz_8", "El tercer dígito de la velocidad de la luz en metros por segundo, no se olvide de sumarlo para sacar la contraseña."),
            new Word("pistas_voz_9", "En la lista de los reyes Godos está la clave. El que empieza por T y está varias veces..."),
            new Word("pistas_voz_10", "Es fundamental aplicar la transformada de Fourier, ahí está la clave para obtener la contraseña."),
            new Word("pistas_voz_11", "El mes del desembarco de Normandía, es necesario para el cálculo."),
            new Word("pistas_voz_12", "En el segundo versículo del evangelio de San Marcos hay un dato que no debe pasar por alto."),
            new Word("pistas_voz_13", "¿En qué región hizo la instrucción? Empiece por ahí y el resto saldrá solo."),
            new Word("pistas_voz_14", "¿Cuántos actores rubios aparecen en el quinto capítulo de Médico de Família? Cuéntelos y agréguelos al cálculo de la contraseña."),

            new Word("pulsarInterruptor0_1_interaction_description", "Pulsar interruptor 1"),
            new Word("pulsarInterruptor1_1_interaction_description", "Pulsar interruptor 2"),
            new Word("pulsarInterruptor2_1_interaction_description", "Pulsar interruptor 3"),
            new Word("pulsarInterruptor3_1_interaction_description", "Pulsar interruptor 4"),
            new Word("pulsarInterruptor4_1_interaction_description", "Pulsar interruptor 5"),
            new Word("pulsarInterruptor5_1_interaction_description", "Pulsar interruptor 6"),
            new Word("pulsarInterruptor6_1_interaction_description", "Pulsar interruptor 7"),
            new Word("pulsarInterruptor7_1_interaction_description", "Pulsar interruptor 8"),
            new Word("pulsarInterruptor8_1_interaction_description", "Pulsar interruptor 9"),
            new Word("pulsarInterruptor9_1_interaction_description", "Pulsar interruptor 10"),
            new Word("pulsarInterruptor_text", "Pulsas el interruptor {0}. Se queda hundido e iluminado."),

            new Word("desactivarInterruptor0_1_interaction_description", "Desactivar interruptor 1"),
            new Word("desactivarInterruptor1_1_interaction_description", "Desactivar interruptor 2"),
            new Word("desactivarInterruptor2_1_interaction_description", "Desactivar interruptor 3"),
            new Word("desactivarInterruptor3_1_interaction_description", "Desactivar interruptor 4"),
            new Word("desactivarInterruptor4_1_interaction_description", "Desactivar interruptor 5"),
            new Word("desactivarInterruptor5_1_interaction_description", "Desactivar interruptor 6"),
            new Word("desactivarInterruptor6_1_interaction_description", "Desactivar interruptor 7"),
            new Word("desactivarInterruptor7_1_interaction_description", "Desactivar interruptor 8"),
            new Word("desactivarInterruptor8_1_interaction_description", "Desactivar interruptor 9"),
            new Word("desactivarInterruptor9_1_interaction_description", "Desactivar interruptor 10"),
            new Word("desactivarInterruptor_text", "Pulsas el interruptor {0} para desactivarlo. Se queda subido y apagado."),

            new Word("tirarPalanca_1_interaction_description", "Tirar palanca"),
            new Word("tirarPalanca_text", "Tiras de la palanca. No sucede nada."),

            new Word("connectCable_1_interaction_description", "Conectar {cable} con {other}"),
            new Word("connectCable_text", "Enchufas {0} en {1}."),

            new Word("disconnectCable_1_interaction_description", "Desconectar {cable} del {other}"),
            new Word("disconnectCable_text", "Desconectas {0} y {1}."),

            new Word("untarteAceite_1_interaction_description", "Untarte el aceite del frasco"),
            new Word("untarteAceite_text", "Colocas el frasco por encima de tu cabeza y lo vuelcas poco a poco, notando como el correoso aceite cae por tu cabeza y tus hombros, envolviéndote con su repugnante textura y su pestilente olor. Retienes una arcada."),

            new Word("meterteRejilla_1_interaction_description", "Meterte por {thing}"),
            new Word("meterteRejilla_text", "Te metes por {0}. Gracias al aceite impregnado en tu cuerpo consigues deslizarte a través del estrecho hueco. Llegas a un lavabo."),
            new Word("meterteRejilla_failure_text", "Intentas meterte por {0}, pero las paredes son muy rugosas y los hombros se te atascan."),

            //new Word("saludo_1_interaction_description", "{main} saluda a {saluted}."),
            //new Word("saludo_11_interaction_description", "{saluted} saluda a {main}."),
            //new Word("saludo_text", "Buenas {0}."),
            //new Word("respuesta_text", "Hola {0}."),

            //new Word("estornudo_1_interaction_description", "{main} estornuda."),
            //new Word("estornudo_1_text", "{0} estornuda sonoramente."),
            //new Word("estornudo_11_interaction_description", "{main} se limpia con la manga izquierda."),
            //new Word("estornudo_2_text", "{0} se limpia la nariz con el dorso de la manga izquierda."),
            //new Word("estornudo_12_interaction_description", "{main} se limpia con la manga derecha."),
            //new Word("estornudo_3_text", "{0} se limpia la nariz con el dorso de la manga derecha."),
        };
    }
}
