using Outputer.Choicing;

namespace LaMision.Core
{
    internal sealed class AutomaticInput
    {
        private Input? input;

        public AutomaticInput()
        {
            input = null;
        }

        public Input Flush(Input defaultInput)
        {
            if (input is null)
                return defaultInput;

            var inputToReturn = input;
            Clear();

            return inputToReturn;
        }

        public void Set(Input input) =>
            this.input = input;

        public void Clear() =>
            input = null;
    }
}
