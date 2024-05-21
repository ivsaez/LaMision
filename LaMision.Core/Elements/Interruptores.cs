using Items;
using ItemTypes;

namespace LaMision.Core.Elements
{
    public class Interruptores : ArticledFurniture
    {
        public const int Total = 10;

        private bool[] interruptores = new bool[Total];

        public Interruptores(string id) 
            : base(id, 10, 1, false, Genere.Masculine, Number.Plural)
        {
            for (int i = 0; i < interruptores.Length; i++)
            {
                interruptores[i] = false;
            }
        }

        public bool IsPulsed(int i) => interruptores[i];

        public bool Pulse(int i) => interruptores[i] = true;

        public bool UnPulse(int i) => interruptores[i] = false;
    }
}
