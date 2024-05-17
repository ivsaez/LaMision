using Agents;
using Languager.Extensions;
using Outputer;
using Rand;
using Rolling;
using Stories;
using Stories.Builders;

namespace LaMision.Core.Vaults
{
    public static class RadioVault
    {
        public static StoriesVault Get()
        {
            return new StoriesVault(
                StoryletBuilder.Create("mensajeLevanta")
                .BeingRepeteable()
                .ForMachines()
                .WithAgentsScope()
                .WithEnvPreconditions(pre => pre.IsState(States.Initial))
                .WithPreconditions((pre) =>
                {
                    var sujeto = pre.World.Agents.GetOne("sujeto");
                    return sujeto.Position.Machine.CurrentState != Position.Standing;
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
                .Finish(),

                StoryletBuilder.Create("mision")
                .BeingGlobalSingle()
                .ForMachines()
                .WithAgentsScope()
                .WithEnvPreconditions(pre => pre.IsState(States.Initial))
                .WithPreconditions((pre) =>
                {
                    var sujeto = pre.World.Agents.GetOne("sujeto");
                    return sujeto.Position.Machine.CurrentState == Position.Standing;
                })
                .WithInteraction((post) =>
                {
                    post.World.State.Transite(States.Mision);
                    var main = post.Main;
                    var sujeto = post.World.Agents.GetOne("sujeto");

                    return new Output(
                        new Pharagraph("mision_text".trans()),
                        new Conversation()
                            .With(main.Name, "mision_text_1".trans())
                            .With(sujeto.Name, "mision_text_2".trans())
                            .With(main.Name, "mision_text_3".trans())
                            .With(sujeto.Name, "mision_text_4".trans())
                            .With(main.Name, "mision_text_5".trans())
                            .With(sujeto.Name, "mision_text_6".trans())
                            .With(main.Name, "mision_text_7".trans())
                            .With(sujeto.Name, "mision_text_8".trans())
                            .With(main.Name, "mision_text_9".trans())
                            .With(sujeto.Name, "mision_text_10".trans())
                            .With(main.Name, "mision_text_11".trans()));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                 StoryletBuilder.Create("mensajePasillo")
                .BeingRepeteable()
                .ForMachines()
                .WithAgentsScope()
                .WithEnvPreconditions(pre => pre.IsState(States.Mision))
                .WithPreconditions((pre) =>
                {
                    var sujeto = pre.World.Agents.GetOne("sujeto");

                    return pre.World.Map.GetUbication(sujeto).Id == "pasillo";
                })
                .WithInteraction((post) =>
                {
                    return new Output(
                        new Pharagraph("mensajePasillo_text_1".trans()),
                        new Conversation()
                            .With(post.Main.Name, new string[]
                            {
                                "mensajePasillo_voz_1".trans(),
                                "mensajePasillo_voz_2".trans(),
                                "mensajePasillo_voz_3".trans(),
                                "mensajePasillo_voz_4".trans(),
                            }.Random())
                        );
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish()
                );
        }
    }
}
