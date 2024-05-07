using Agents;
using Desiring;
using Languager.Extensions;
using Languager;
using Outputer.Choicing;
using Outputer;
using Saver;
using Stories;
using Worlding;

namespace LaMision.Core
{
    public class Game : ISavable
    {
        private Historic historic;
        private World world;
        private DesireVault desires;
        private TurnSelector turnSelector;
        private OnGoing onGoing;

        public Game(
            Language lang,
            World world,
            IEnumerable<DictionaryProvider> providers,
            IEnumerable<StoriesVault> storiesVaults)
        {
            historic = new Historic();
            this.world = world;
            desires = new DesireVault();

            configureDictionary(lang, providers);
            turnSelector = new TurnSelector(world.Agents.All, configureDeck(storiesVaults));
            onGoing = new OnGoing(world, historic);
        }

        private void configureDictionary(Language lang, IEnumerable<DictionaryProvider> providers)
        {
            var dictionary = new Dictionary(lang);

            foreach (var provider in providers)
                dictionary.Load(provider);

            Translator.Instance.Dictionary = dictionary;
        }

        private StoriesDeck configureDeck(IEnumerable<StoriesVault> storiesVaults)
        {
            var deck = new StoriesDeck();

            foreach (var vault in storiesVaults)
                deck.IncorporateVault(vault);

            return deck;
        }

        public Save ToSave() =>
            new Save(GetType().Name)
                .WithSavable(nameof(historic), historic)
                .WithSavable(nameof(world), world);

        public void Load(Save save)
        {
            historic = save.GetSavable<Historic>(nameof(historic));
            world = save.GetSavable<World>(nameof(world));
        }

        public Output Start()
        {
            return Output.FromTexts("initial".trans());
        }

        public GameInteraction NextAction(Input input)
        {
            input = onGoing.OverrideWithAutomatic(input);

            if (onGoing.IsEmpty)
            {
                var nextTurn = turnSelector.GetNext(world, historic);
                if (nextTurn.IsNothing)
                    return GameInteraction.Ending;

                onGoing.AssignSelection(nextTurn);

                if (nextTurn.Agent.Actioner == Actioner.Human)
                    return GameInteraction.New(onGoing.Step);

                onGoing.SelectRandomStorylet();

                var gameInteraction = GameInteraction.New(onGoing.Step);
                if (onGoing.IsStepEnding)
                {
                    var output = onGoing.PassTurnForMainAgent();
                    gameInteraction.WithExtraOutput(output);
                    onGoing.Clear();
                }

                return gameInteraction;
            }
            else
            {
                if (onGoing.ThereIsOnGoingStory)
                {
                    onGoing.InteractWithStory(input);
                    return buildGameInteractionBasedOnStep();
                }
                else
                {
                    onGoing.SelectStoryletByChoice(input);
                    return buildGameInteractionBasedOnStep();
                }
            }
        }

        private GameInteraction buildGameInteractionBasedOnStep()
        {
            if (onGoing.IsStepEnding)
            {
                var output = onGoing.PassTurnForMainAgent();
                var step = onGoing.Step;
                onGoing.Clear();
                return GameInteraction.New(step).WithExtraOutput(output);
            }

            if (onGoing.NextAnswererIsHuman)
                return GameInteraction.New(onGoing.Step);

            onGoing.SetAutomaticDecision(desires);
            return GameInteraction.Automatic(onGoing.Step);
        }
    }
}
