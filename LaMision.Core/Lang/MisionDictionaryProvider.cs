using Languager;

namespace LaMision.Core.Lang
{
    public class MisionDictionaryProvider : DictionaryProvider
    {
        protected override IDictionaryLoader Spanish => new SpanishDictionaryLoader();
    }
}
