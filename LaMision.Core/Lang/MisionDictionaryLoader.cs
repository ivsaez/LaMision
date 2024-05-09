using Languager;

namespace LaMision.Core.Lang
{
    public class AdventureDictionaryProvider : DictionaryProvider
    {
        protected override IDictionaryLoader Spanish => new SpanishDictionaryLoader();
    }
}
