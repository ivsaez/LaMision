using Outputer.Choicing;
using Outputer;
using Stories;
using System.Text;

namespace LaMision.Core
{
    public sealed class GameInteraction
    {
        private Output? output;
        private readonly Choices? choices;

        private GameInteraction(Output? output, Choices? choices, bool isEnding, bool isSubInteraction)
        {
            this.output = output;
            this.choices = choices;
            IsEnding = isEnding;
            IsSubInteraction = isSubInteraction;
        }

        public bool IsEnding { get; }
        public bool IsSubInteraction { get; }

        public Output Output
        {
            get
            {
                if (output is null)
                    throw new InvalidOperationException(nameof(output));

                return output;
            }
        }

        public Choices Choices
        {
            get
            {
                if (choices is null)
                    throw new InvalidOperationException(nameof(choices));

                return choices;
            }
        }

        public bool HasText => output is not null;
        public bool HasChoices => choices is not null;

        public GameInteraction WithExtraOutput(Output output)
        {
            if (this.output is null)
                this.output = output;
            else
                this.output.Add(output);

            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (HasText)
                builder.Append(Output.ToString());

            if (HasChoices)
                builder.Append(Choices.ToString());

            return builder.ToString();
        }

        public static GameInteraction Ending => 
            new GameInteraction(null, null, true, false);

        public static GameInteraction New(Step step, bool isSubInteraction = false) => 
            new GameInteraction(step.Output, step.Choices, false, isSubInteraction);

        public static GameInteraction Automatic(Step step) => 
            new GameInteraction(step.Output, null, false, false);
    }
}
