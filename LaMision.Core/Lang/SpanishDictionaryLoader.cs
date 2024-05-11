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
