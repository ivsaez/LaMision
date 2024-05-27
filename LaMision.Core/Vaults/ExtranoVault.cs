using Agents;
using Agents.Extensions;
using LaMision.Core.Elements;
using Languager.Extensions;
using Outputer;
using Rand;
using Rolling;
using StateMachine;
using Stories;
using Stories.Builders;
using System.Runtime.InteropServices;

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

                    var texts = new List<string>
                    {
                        "mirarExtrano_text_1".trans(),
                        "mirarExtrano_text_2".trans()
                    };

                    if (post.Main.Position.Machine.CurrentState != Position.Standing)
                    {
                        post.Main.Position.Machine.Transite(Position.Standing);
                        texts.Add("mirarExtrano_text_3".trans());
                    }

                    return Output.FromTexts(texts.ToArray());
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
                        && pre.EveryoneStanding()
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
            .Finish(),

            StoryletBuilder.Create("extranoAmenazaPuno")
            .BeingRepeteable()
            .ForMachines()
            .WithDescriptor("other")
            .WithAgentsScope()
            .WithEnvPreconditions(pre => pre.IsState(States.Fight))
            .WithPreconditions((pre) =>
            {
                return pre.EveryoneConscious()
                    && pre.MainPlaceIsEnlighted()
                    && pre.Main.Cast<MisionAgent>().IsAlive
                    && pre.Agent("other").Cast<MisionAgent>().IsAlive
                    && pre.Main.Id == "extrano";
            })
            .WithInteraction((post) => Output.FromTexts("extranoAmenazaPuno_text".trans()))
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPuno_bloquear_text", true);
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoAmenazaPuno_tirarte_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPuno_golpear_text", true);
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPuno_fintar_text", true);
                })
                    .WithDriver("other")
                    .Build()
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish(),

            StoryletBuilder.Create("extranoAmenazaPatada")
            .BeingRepeteable()
            .ForMachines()
            .WithDescriptor("other")
            .WithAgentsScope()
            .WithEnvPreconditions(pre => pre.IsState(States.Fight))
            .WithPreconditions((pre) =>
            {
                return pre.EveryoneConscious()
                    && pre.MainPlaceIsEnlighted()
                    && pre.Main.Cast<MisionAgent>().IsAlive
                    && pre.Agent("other").Cast<MisionAgent>().IsAlive
                    && pre.Main.Id == "extrano";
            })
            .WithInteraction((post) => Output.FromTexts("extranoAmenazaPatada_text".trans()))
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoAmenazaPatada_bloquear_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPatada_tirarte_text", false);
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPatada_golpear_text", false);
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return hit(post, "extranoAmenazaPatada_fintar_text", false);
                })
                    .WithDriver("other")
                    .Build()
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish()
            );
        }

        private static Output hit(PredefinedPostconditions post, string text_key, bool upper)
        {
            var sujeto = post.Agent("other").Cast<MisionAgent>();
            sujeto.Hit();

            if (!sujeto.IsAlive)
                return Output.FromTexts("muerte_pelea".trans(), "fin".trans());

            var part = upper
                ? new string[]
            {
                "head_part_1",
                "head_part_2",
                "head_part_3"
            }.Random().trans()
            : new string[]
            {
                "body_part_1",
                "body_part_2",
                "body_part_3"
            }.Random().trans();

            return new Output(
                new Pharagraph(text_key.trans(part)),
                new Conversation().With("Extraño", new string[]
                {
                    "hit_celebration_1",
                    "hit_celebration_2",
                    "hit_celebration_3",
                    "hit_celebration_4",
                    "hit_celebration_5",
                    "hit_celebration_6",
                }.Random().trans())
            );
        }
    }
}
