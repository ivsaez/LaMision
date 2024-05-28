using Agents;

namespace LaMision.Core.Elements
{
    public class SimonEstevez : MisionAgent
    {
        private bool revelated;

        public SimonEstevez(string id) 
            : base(id, "Mirko", "Kazinsky", Importance.Main)
        {
            revelated = false;
        }

        public void Revelate() => revelated = true;

        public bool IsRevelated => revelated;

        public string TrueName => revelated
            ? "Simón"
            : Name;
    }
}
