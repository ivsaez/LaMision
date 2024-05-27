using Agents;
using Agents.Extensions;
using LaMision.Core.Elements;
using Languager.Extensions;
using Outputer;
using Rolling;
using StateMachine;
using Stories;
using Stories.Builders;

namespace LaMision.Core.Vaults
{
    public static class ExtranoVault
    {
        public static StoriesVault Get()
        {
            return new StoriesVault(
                StoryletBuilder.Create("mirarExtrano")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("other")
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;

                    return pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id))
                        && pre.Agent("other").Id == "extrano";
                })
                .WithInteraction((post) =>
                {
                    var extrano = post.Agent("other");
                    extrano.Status.Machine.Transite(Status.Conscious);

                    return Output.FromTexts(
                        "mirarExtrano_text_1".trans(),
                        "mirarExtrano_text_2".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("extranoHabla")
                .BeingGlobalSingle()
                .ForMachines()
                .WithDescriptor("other")
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneConscious()
                        && pre.MainPlaceIsEnlighted()
                        && pre.Main.Id == "extrano";
                })
                .WithInteraction((post) =>
                {
                    var sujeto = post.Agent("other").Cast<SimonEstevez>();

                    return new Output(
                        new Pharagraph("extranoHabla_text_1".trans()),
                        new Conversation()
                            .With("Extraño", "extranoHabla_mensaje_1".trans())
                            .With(sujeto.TrueName, "extranoHabla_mensaje_2".trans())
                            .With("Extraño", "extranoHabla_mensaje_3".trans())
                            .With(sujeto.TrueName, "extranoHabla_mensaje_4".trans())
                            .With("Extraño", "extranoHabla_mensaje_5".trans())
                            .With(sujeto.TrueName, "extranoHabla_mensaje_6".trans())
                            .With("Extraño", "extranoHabla_mensaje_7".trans())
                            .With(sujeto.TrueName, "extranoHabla_mensaje_8".trans())
                            .With("Extraño", "extranoHabla_mensaje_9".trans())
                            .With(sujeto.TrueName, "extranoHabla_mensaje_10".trans())
                            .With("Extraño", "extranoHabla_mensaje_11".trans()),
                        new Pharagraph("extranoHabla_text_2".trans())
                        );
                })
                .WithSubinteraction((post) =>
                {
                    post.World.State.Transite(States.Fight);

                    return Output.FromTexts(
                        "extranoHabla_text_3".trans(),
                        "extranoHabla_text_4".trans(),
                        "extranoHabla_text_5".trans(),
                        "extranoHabla_text_6".trans(),
                        "extranoHabla_text_7".trans(),
                        "extranoHabla_text_8".trans(),
                        "extranoHabla_text_9".trans(),
                        "extranoHabla_text_10".trans()
                        );
                })
                    .WithDriver("other")
                    .Build()
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish()
            );
        }
    }
}
