using Rand;
using Stories;
using Worlding;

namespace LaMision.Core
{
    internal sealed class TurnSelector
    {
        private readonly IEnumerable<IWorldAgent> agents;
        private readonly StoriesDeck deck;

        private List<IWorldAgent> remaining;
        private HashSet<IWorldAgent> alreadyChecked;

        public TurnSelector(IEnumerable<IWorldAgent> agents, StoriesDeck deck)
        {
            if (!agents.Any())
                throw new ArgumentException(nameof(agents));

            this.agents = agents;
            this.deck = deck;
            remaining = new List<IWorldAgent>(this.agents);
            alreadyChecked = new HashSet<IWorldAgent>();
        }

        public NextTurn GetNext(World world, Historic historic)
        {
            initializeTurning();

            IWorldAgent? selectedAgent = null;
            var rolledStories = new RolledStories();

            while (rolledStories.IsEmpty && alreadyChecked.Count != agents.Count())
            {
                if (!remaining.Any())
                    remaining = new List<IWorldAgent>(agents.Where(agent => !alreadyChecked.Contains(agent)));

                int index = (int)Rnd.Instance.Random((uint)remaining.Count);

                selectedAgent = remaining[index];
                remaining.RemoveAt(index);

                alreadyChecked.Add(selectedAgent);

                var deckSelection = deck.GetValidStories(world, historic);
                rolledStories = deckSelection.GetValidStories(selectedAgent, world, historic);
            }

            if (rolledStories.IsEmpty)
                return NextTurn.Nothing;

            return NextTurn.New(selectedAgent!, rolledStories);
        }

        private void initializeTurning()
        {
            if (!remaining.Any())
                remaining = new List<IWorldAgent>(agents);

            alreadyChecked.Clear();
        }
    }

    internal sealed class NextTurn
    {
        private readonly IWorldAgent? agent;
        private readonly RolledStories? rolledStories;

        private NextTurn(IWorldAgent? agent, RolledStories? rolledStories)
        {
            this.agent = agent;
            this.rolledStories = rolledStories;
        }

        public IWorldAgent Agent
        {
            get
            {
                if (agent is null)
                    throw new InvalidOperationException(nameof(agent));

                return agent;
            }
        }

        public RolledStories RolledStories
        {
            get
            {
                if (rolledStories is null)
                    throw new InvalidOperationException(nameof(rolledStories));

                return rolledStories;
            }
        }

        public bool IsNothing =>
            agent is null && rolledStories is null;

        public static NextTurn Nothing =>
            new NextTurn(null, null);

        public static NextTurn New(IWorldAgent agent, RolledStories rolledStories) =>
            new NextTurn(agent, rolledStories);
    }
}
