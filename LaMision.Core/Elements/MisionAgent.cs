using AgentBody;
using Agents;
using AgentStats;
using Desiring;
using Saver;
using Worlding;

namespace LaMision.Core.Elements
{
    public class MisionAgent : WorldAgent, ICarrier, IDesirer, IPhysical
    {
        public MisionAgent(string id, string name, string surname, Importance importance)
            : base(id, name, surname, importance)
        {
            Carrier = new Carrier(120, 50);
            Desires = new Desires();
            Decider = new Decider();
            PhysicalStats = new PhysicalStats(100, 1, 1, 1, 1, 1, 1, 1, 1);
        }

        public Carrier Carrier { get; private set; }

        public Desires Desires { get; private set; }
        public Decider Decider { get; private set; }

        public PhysicalStats PhysicalStats { get; private set; }

        public void Hit() => PhysicalStats.Vitality.Decrease(20);

        public bool IsAlive => PhysicalStats.Vitality.Value > 0;

        protected override object clone()
        {
            var clone = new MisionAgent(Id, Name, Surname, Importance);

            clone.Carrier = (Carrier)Carrier.Clone();
            clone.PhysicalStats = (PhysicalStats)PhysicalStats.Clone();

            return clone;
        }

        protected override void load(Save save)
        {
            Carrier = save.GetSavable<Carrier>(nameof(Carrier));
            PhysicalStats = save.GetSavable<PhysicalStats>(nameof(PhysicalStats));
        }

        protected override Save save() =>
            new Save(Id)
                .WithSavable(nameof(Carrier), Carrier)
                .WithSavable(nameof(PhysicalStats), PhysicalStats);
    }
}
