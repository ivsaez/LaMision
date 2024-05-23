using Items;
using ItemTypes;

namespace LaMision.Core.Elements
{
    public class Frasco : ArticledItem
    {
        private bool empty;

        public Frasco(string id) 
            : base(id, 2, 1, Genere.Masculine, Number.Singular)
        {
            empty = false;
        }

        public bool IsEmpty => empty;

        public void Empty() => empty = true;
    }
}
