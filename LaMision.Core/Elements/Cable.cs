using Items;
using ItemTypes;

namespace LaMision.Core.Elements
{
    public class Cable : ArticledFurniture
    {
        private string connection;

        public Cable(string id)
            : base(id, 1, 1, false, Genere.Masculine, Number.Singular)
        {
            connection = string.Empty;
        }

        public void UnConnect() => connection = string.Empty;

        public void Connect(Cable cable) 
        {
            connection = cable.Id;
        }

        public bool IsConnected => connection != string.Empty;

        public string Connection => connection;
    }
}
