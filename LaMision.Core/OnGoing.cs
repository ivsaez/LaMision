using Contexting;
using Desiring;
using Outputer.Choicing;
using Outputer;
using Stories;
using Worlding;
using Rand;

namespace LaMision.Core
{
    internal sealed class OnGoing
    {
        private readonly World world;

        private IWorldAgent? agent;
        private Choices? choices;

        private OnGoingStory onGoingStory;
        private AutomaticInput automaticInput;

        public OnGoing(World world, Historic historic)
        {
            this.world = world;
            onGoingStory = new OnGoingStory(world, historic);
            automaticInput = new AutomaticInput();
        }

        public bool IsEmpty => agent is null;

        public bool ThereIsOnGoingStory => !onGoingStory.IsEmpty;

        public bool NextAnswererIsHuman => onGoingStory.NextAnswererIsHuman;

        public bool IsStepEnding => onGoingStory.IsStepEnding;

        public Step Step
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException("No step in empty on going.");

                if (onGoingStory.IsEmpty)
                    return new Step(Output.Empty, choices!);

                return onGoingStory.LastStep;
            }
        }

        public void AssignSelection(NextTurn nextTurn)
        {
            agent = nextTurn.Agent;
            choices = nextTurn.RolledStories.Choices(world.Existents);
        }

        public void SelectRandomStorylet()
        {
            checkNotEmpty();
            var selectedChoice = choices!.Options.Random();
            var rolledStorylet = (RolledStorylet)selectedChoice.Function();

            onGoingStory.Assign(rolledStorylet);
            onGoingStory.Interact();
        }

        public void SelectStoryletByChoice(Input input)
        {
            checkNotEmpty();
            var selectedChoice = choices!.Select(input);
            var rolledStorylet = (RolledStorylet)selectedChoice.Function();

            onGoingStory.Assign(rolledStorylet);
            onGoingStory.Interact();
        }

        public void InteractWithStory(Input input) =>
            onGoingStory.Interact(input);

        public Output PassTurnForMainAgent()
        {
            checkNotEmpty();

            var turneds = onGoingStory.PassTurn();
            var context = new Context<IWorldAgent, IWorldItem, IWorldMapped>(agent!, world.Existents);
            return turneds.GetManyCombined(context.All.Select(identifiable => identifiable.Id).ToArray());
        }

        public void SetAutomaticDecision(DesireVault desires) =>
            automaticInput.Set(onGoingStory.GetAutomaticDecision(desires));

        public Input OverrideWithAutomatic(Input input) =>
            automaticInput.Flush(input);

        public void Clear()
        {
            agent = null;
            choices = null;
            automaticInput.Clear();
            onGoingStory.Clear();
        }

        private void checkNotEmpty()
        {
            if (IsEmpty)
                throw new InvalidOperationException("No on going agent.");
        }
    }
}
