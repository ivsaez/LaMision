using Items;
using ItemTypes;
using Worlding;

namespace LaMision.Core.Elements
{
    public class Puerta : ArticledOpenableFurniture
    {
        private Func<World, string>? connection;

        public Puerta(string id, uint space, uint weight, bool external, Genere genere, Number number, IItem? key = null) 
            : base(id, space, weight, external, genere, number, key)
        {
        }

        public Puerta WithConnection(Func<World, string> connection)
        {
            this.connection = connection;
            return this;
        }

        public string Connect(World world)
        {
            if (connection is null)
                return string.Empty;

            return connection(world);
        }
    }
}
