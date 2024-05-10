using Languager;

namespace LaMision.Core.Lang
{
    internal class SpanishDictionaryLoader : IDictionaryLoader
    {
        public IEnumerable<Word> Words => new List<Word>
        {
            new Word("initial", "La historia comienza."),

            new Word("bedRoom_name", "dormitorio"),
            new Word("bedRoom_description", "El dormitorio es una modesta estancia con una cama, una mesita con un cajón y una pequeña ventana."),

            new Word("corridor_name", "pasillo"),
            new Word("corridor_description", "El pasillo está completamente vacío, salvo por un cuadro."),
            
            new Word("lampara_name", "lampara"),
            new Word("lampara_description", "La lámpara es de tipo plafón de forma rectangular. Emite una luz blanquecina."),

            new Word("bed_name", "cama"),
            new Word("bed_description", "Se trata de una cama para una sola persona."),

            new Word("table_name", "mesa"),
            new Word("table_description", "Es una mesa cuadrada de madera."),

            new Word("window_name", "ventana"),
            new Word("window_description", "Es una pequeña ventana."),

            new Word("rock_name", "piedra"),
            new Word("rock_description", "Es una simple piedra que cabe en la mano."),

            new Word("mochila_name", "mochila"),
            new Word("mochila_description", "Es una mochila vieja de color marrón."),

            new Word("bolsa_name", "bolsa"),
            new Word("bolsa_description", "Es una bolsa de tela de color naranja."),

            new Word("cuadro_name", "cuadro"),
            new Word("cuadro_description", "Es un cuadro de unos perros jugando al poker."),

            new Word("humo_name", "humo"),
            new Word("humo_description", "Hay una nuve de humo gris flotando en la estancia."),

            new Word("mirar_mapped_1_interaction_description", "{main} mira el lugar donde se encuentra."),

            new Word("mirar_item_1_interaction_description", "{main} mira {thing}."),

            new Word("coger_1_interaction_description", "{main} coge {thing}."),
            new Word("coger_good", "{0} coge {1} y se la guarda."),
            new Word("coger_big", "{0} no puede coger {1} porque es demasiado grande."),
            new Word("coger_heavy", "{0} no puede coger {1} porque pesa demasiado."),
            new Word("coger_nobag", "{0} no puede coger {1} porque no tiene donde guardar cosas."),

            new Word("dejar_1_interaction_description", "{main} deja {thing}."),
            new Word("dejar", "{0} deja {1} en el suelo."),

            new Word("ir_1_interaction_description", "{main} va hacia {place}."),
            new Word("ir", "{0} se desplaza hacia {1}."),
            new Word("ir_door", "{0} no puede ir hacia {1} sin antes abrir la puerta."),

            new Word("saludo_1_interaction_description", "{main} saluda a {saluted}."),
            new Word("saludo_11_interaction_description", "{saluted} saluda a {main}."),
            new Word("saludo_text", "Buenas {0}."),
            new Word("respuesta_text", "Hola {0}."),

            new Word("pedirse_1_interaction_description", "{main} se tira un cuesco."),
            new Word("pedirse_text", "{0} levanta la pierna y se tira un sonoro pedo."),
            new Word("pedirse_conversation", "¡Ups! Perdón."),

            new Word("sacamoco_1_interaction_description", "{main} se saca una burilla."),
            new Word("sacamoco_text", "{0} se saca una burilla, hace una pelotilla y la proyecta contra el suelo con los dedos."),

            new Word("estornudo_1_interaction_description", "{main} estornuda."),
            new Word("estornudo_1_text", "{0} estornuda sonoramente."),
            new Word("estornudo_11_interaction_description", "{main} se limpia con la manga izquierda."),
            new Word("estornudo_2_text", "{0} se limpia la nariz con el dorso de la manga izquierda."),
            new Word("estornudo_12_interaction_description", "{main} se limpia con la manga derecha."),
            new Word("estornudo_3_text", "{0} se limpia la nariz con el dorso de la manga derecha."),
        };
    }
}
