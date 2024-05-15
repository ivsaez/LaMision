using Items;
using ItemTypes;

namespace LaMision.Core.Elements
{
    public class Puerta : ArticledOpenableFurniture
    {
        public Puerta(string id, uint space, uint weight, bool external, Genere genere, Number number, IItem? key = null) 
            : base(id, space, weight, external, genere, number, key)
        {
        }
    }
}
