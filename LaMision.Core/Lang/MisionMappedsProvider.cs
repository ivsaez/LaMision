using Languager;

namespace LaMision.Core.Lang
{
    public class MisionMappedsProvider : DictionaryProvider
    {
        protected override IDictionaryLoader Spanish => new SpanishMappedsDictionaryLoader();
    }
}
