using AgentBody;
using Agents;
using Desiring;
using Saver;
using Worlding;

namespace LaMision.Core.Elements
{
    public class MisionAgent : WorldAgent, ICarrier, IDesirer
    {
        public MisionAgent(string id, string name, string surname, Importance importance)
            : base(id, name, surname, importance)
        {
            Carrier = new Carrier(120, 50);
            Desires = new Desires();
            Decider = new Decider();
        }

        public Carrier Carrier { get; private set; }

        public Desires Desires { get; private set; }
        public Decider Decider { get; private set; }

        protected override object clone()
        {
            var clone = new MisionAgent(Id, Name, Surname, Importance);

            clone.Carrier = (Carrier)Carrier.Clone();

            return clone;
        }

        protected override void load(Save save)
        {
            Carrier = save.GetSavable<Carrier>(nameof(Carrier));
        }

        protected override Save save() =>
            new Save(Id)
                .WithSavable(nameof(Carrier), Carrier);
    }
}
