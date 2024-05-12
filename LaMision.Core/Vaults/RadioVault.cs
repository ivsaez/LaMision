using AgentBody;
using Agents;
using Agents.Extensions;
using ClimaticsLang;
using Items;
using ItemsLang;
using LaMision.Core.Elements;
using Languager.Extensions;
using Logic;
using Mapping;
using MappingLang;
using Outputer;
using Rand;
using Rolling;
using Stories;
using Stories.Builders;
using Worlding;

namespace LaMision.Core.Vaults
{
    public static class RadioVault
    {
        public static StoriesVault Get()
        {
            var mensajeLevanta = StoryletBuilder.Create("mensajeLevanta")
                .BeingRepeteable()
                .ForMachines()
                .WithAgentsScope()
                .WithPreconditions((pre) => 
                {
                    return pre.EveryoneConscious()
                    && !pre.World.Knowledge.Exists(Sentence.Build("FirstUp", "Mirko"));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;

                    var text = post.Historic.HasHappenedTimes(new Snapshot("mensajeLevanta", main.Id), 2)
                        ? "mensajeLevanta_text_2".trans()
                        : "mensajeLevanta_text_1".trans();

                    return new Output(
                        new Pharagraph(text),
                        new Conversation()
                            .With(main.Name, new string[] 
                            {
                                "mensajeLevanta_voz_1".trans(),
                                "mensajeLevanta_voz_2".trans(),
                                "mensajeLevanta_voz_3".trans(),
                                "mensajeLevanta_voz_4".trans(),
                                "mensajeLevanta_voz_5".trans(),
                            }.Random())
                        );
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();

            return new StoriesVault(
                mensajeLevanta);
        }
    }
}
