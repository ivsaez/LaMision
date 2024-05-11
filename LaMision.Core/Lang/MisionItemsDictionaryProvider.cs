using Languager;

namespace LaMision.Core.Lang
{
    public class MisionItemsDictionaryProvider : DictionaryProvider
    {
        protected override IDictionaryLoader Spanish => new SpanishItemsDictionaryLoader();
    }
}
