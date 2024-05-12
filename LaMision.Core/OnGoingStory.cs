using Agents;
using Agents.Extensions;
using Desiring;
using Outputer.Choicing;
using Rolling;
using Stories;
using Worlding;

namespace LaMision.Core
{
    internal sealed class OnGoingStory
    {
        private readonly World world;
        private readonly Historic historic;

        private RolledStorylet? rolledStorylet;
        private IStory? story;
        private Step? lastStep;

        public OnGoingStory(World world, Historic historic)
        {
            this.world = world;
            this.historic = historic;

            Clear();
        }

        public bool IsStepEnding
        {
            get
            {
                if (lastStep is null)
                    return true;

                return lastStep.IsEnding;
            }
        }

        public Step LastStep
        {
            get
            {
                if (lastStep is null)
                    throw new InvalidOperationException("There is no last step");

                return lastStep;
            }
        }

        public bool IsEmpty => rolledStorylet is null;

        public bool NextAnswererIsHuman
        {
            get
            {
                checkNotEmpty();
                return story!.Answerer.Actioner == Actioner.Human;
            }
        }

        public Input GetAutomaticDecision(DesireVault desires)
        {
            checkNotEmpty();

            var desirer = story!.Driver.Cast<IDesirer>();
            int decision = desirer!.Decider.Decide(
                world, 
                lastStep!.Choices, 
                rolledStorylet!.Roles, 
                historic, 
                desirer.Desires, 
                desires);
            return new Input(decision);
        }

        public Roles Roles
        {
            get
            {
                checkNotEmpty();
                return rolledStorylet!.Roles;
            }
        }

        public void Assign(RolledStorylet rolledStorylet)
        {
            this.rolledStorylet = rolledStorylet;
            story = rolledStorylet.Execute(world, historic);
        }

        public void Interact(Input? input = default)
        {
            if (input is null)
                input = Input.Void;

            checkNotEmpty();
            lastStep = story!.Interact(input);
        }

        public Turneds PassTurn()
        {
            checkNotEmpty();
            return world.PassTurn(rolledStorylet!.Storylet.Cost);
        }

        public void Clear()
        {
            story = null;
            rolledStorylet = null;
            lastStep = null;
        }

        private void checkNotEmpty()
        {
            if (IsEmpty)
                throw new InvalidOperationException("No on going storylet.");
        }
    }
}
