using Items;
using ItemTypes;

namespace LaMision.Core.Elements
{
    public class Tarjeta : ArticledItem
    {
        public Tarjeta(string id, uint space, uint weight, Genere genere, Number number) 
            : base(id, space, weight, genere, number)
        {
        }
    }
}
