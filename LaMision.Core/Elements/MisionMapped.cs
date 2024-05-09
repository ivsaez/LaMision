using Items;
using Mapping;
using Saver;
using Worlding;

namespace LaMision.Core.Elements
{
    public class MisionMapped : WorldMapped, IArticled
    {
        public MisionMapped(string id, Externality externality, Genere genere, Number number)
            : base(id, externality)
        {
            Articler = new Articler(genere, number);
        }

        public Articler Articler { get; private set; }

        protected override object clone() =>
            new MisionMapped(Id, Externality, Articler.Genere, Articler.Number);

        protected override void load(Save save)
        {
            Articler = save.GetSavable<Articler>(nameof(Articler));
        }

        protected override Save save() =>
            new Save(Id)
                .WithSavable(nameof(Articler), Articler);
    }
}
