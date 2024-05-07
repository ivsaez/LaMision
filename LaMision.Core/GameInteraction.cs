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

        private GameInteraction(Output? output, Choices? choices, bool isEnding)
        {
            this.output = output;
            this.choices = choices;
            IsEnding = isEnding;
        }

        public bool IsEnding { get; }

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

        public static GameInteraction Ending => new GameInteraction(null, null, true);

        public static GameInteraction New(Step step) => new GameInteraction(step.Output, step.Choices, false);

        public static GameInteraction Automatic(Step step) => new GameInteraction(step.Output, null, false);
    }
}
