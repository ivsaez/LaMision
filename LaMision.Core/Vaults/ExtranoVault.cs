using Agents;
using Agents.Extensions;
using LaMision.Core.Elements;
using Languager.Extensions;
using Outputer;
using Rand;
using Rolling;
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
                        && pre.Agent("other").Id == "extrano"
                        && pre.Agent("other").Cast<MisionAgent>().IsAlive;
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

                StoryletBuilder.Create("mirarExtranoMuerto")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("other")
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;

                    return pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id))
                        && pre.Agent("other").Id == "extrano"
                        && !pre.Agent("other").Cast<MisionAgent>().IsAlive;
                })
                .WithInteraction((post) => Output.FromTexts("mirarExtranoMuerto_text".trans()))
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

                    var outputables = new List<IOutputable>
                    {
                        new Pharagraph("extranoHabla_text_1".trans())
                    };

                    if(sujeto.Position.Machine.CurrentState != Position.Standing)
                    {
                        sujeto.Position.Machine.Transite(Position.Standing);
                        outputables.Add(new Pharagraph("extranoHabla_text_levanta".trans()));
                    }

                    outputables.Add(new Conversation()
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
                            .With("Extraño", "extranoHabla_mensaje_11".trans()));

                    outputables.Add(new Pharagraph("extranoHabla_text_2".trans()));

                    return new Output(outputables.ToArray());
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
            .Finish(),

            StoryletBuilder.Create("extranoEsperaCansado")
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
            .WithInteraction((post) => Output.FromTexts("extranoEsperaCansado_text".trans()))
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoEsperaCansado_esperar_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return aggression(post, "extranoEsperaCansado_golpear_text");
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoEsperaCansado_fintar_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish(),

            StoryletBuilder.Create("extranoEsperaGuardia")
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
            .WithInteraction((post) => Output.FromTexts("extranoEsperaGuardia_text".trans()))
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoEsperaGuardia_esperar_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return Output.FromTexts("extranoEsperaGuardia_golpear_text".trans());
                })
                    .WithDriver("other")
                    .Build()
                .WithSubinteraction((post) =>
                {
                    return aggression(post, "extranoEsperaGuardia_fintar_text");
                })
                    .WithDriver("other")
                    .Build()
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish(),

            StoryletBuilder.Create("insultarExtrano")
            .BeingRepeteable()
            .ForHumans()
            .WithDescriptor("other")
            .WithAgentsScope()
            .WithEnvPreconditions(pre => pre.IsState(States.Fight))
            .WithPreconditions((pre) =>
            {
                var main = pre.Main;
                var place = pre.MainPlace;

                return pre.EveryoneConscious()
                    && pre.MainPlaceIsEnlighted()
                    && pre.Agent("other").Id == "extrano"
                    && pre.Main.Cast<MisionAgent>().IsAlive
                    && pre.Agent("other").Cast<MisionAgent>().IsAlive;
            })
            .WithInteraction((post) =>
            {
                return new Output(new Conversation()
                    .With(post.Main.Cast<SimonEstevez>().TrueName, new string[]
                    {
                        "insultarExtrano_insulto_1",
                        "insultarExtrano_insulto_2",
                        "insultarExtrano_insulto_3",
                        "insultarExtrano_insulto_4"
                    }.Random().trans())
                    .With("Extraño", new string[]
                    {
                        "insultarExtrano_respuesta_1",
                        "insultarExtrano_respuesta_2",
                        "insultarExtrano_respuesta_3",
                    }.Random().trans()));
            })
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish(),

            StoryletBuilder.Create("preguntarExtrano")
            .BeingRepeteable()
            .ForHumans()
            .WithDescriptor("other")
            .WithAgentsScope()
            .WithEnvPreconditions(pre => pre.IsState(States.Fight))
            .WithPreconditions((pre) =>
            {
                var main = pre.Main;
                var place = pre.MainPlace;

                return pre.EveryoneConscious()
                    && pre.MainPlaceIsEnlighted()
                    && pre.Agent("other").Id == "extrano"
                    && pre.Main.Cast<MisionAgent>().IsAlive
                    && pre.Agent("other").Cast<MisionAgent>().IsAlive;
            })
            .WithInteraction((post) =>
            {
                return new Output(new Conversation()
                    .With(post.Main.Cast<SimonEstevez>().TrueName, new string[]
                    {
                        "preguntarExtrano_pregunta_1",
                        "preguntarExtrano_pregunta_2",
                        "preguntarExtrano_pregunta_3",
                        "preguntarExtrano_pregunta_4"
                    }.Random().trans())
                    .With("Extraño", new string[]
                    {
                        "preguntarExtrano_respuesta_1",
                        "preguntarExtrano_respuesta_2",
                        "preguntarExtrano_respuesta_3",
                    }.Random().trans()));
            })
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish(),

            StoryletBuilder.Create("calmarExtrano")
            .BeingRepeteable()
            .ForHumans()
            .WithDescriptor("other")
            .WithAgentsScope()
            .WithEnvPreconditions(pre => pre.IsState(States.Fight))
            .WithPreconditions((pre) =>
            {
                var main = pre.Main;
                var place = pre.MainPlace;

                return pre.EveryoneConscious()
                    && pre.MainPlaceIsEnlighted()
                    && pre.Agent("other").Id == "extrano"
                    && pre.Main.Cast<MisionAgent>().IsAlive
                    && pre.Agent("other").Cast<MisionAgent>().IsAlive;
            })
            .WithInteraction((post) =>
            {
                return new Output(new Conversation()
                    .With(post.Main.Cast<SimonEstevez>().TrueName, new string[]
                    {
                        "calmarExtrano_frase_1",
                        "calmarExtrano_frase_2",
                        "calmarExtrano_frase_3",
                        "calmarExtrano_frase_4"
                    }.Random().trans())
                    .With("Extraño", new string[]
                    {
                        "calmarExtrano_respuesta_1",
                        "calmarExtrano_respuesta_2",
                        "calmarExtrano_respuesta_3",
                    }.Random().trans()));
            })
                .WithDriver(Descriptor.MainRole)
                .SetAsRoot()
            .Finish()
            );
        }

        private static Output hit(PredefinedPostconditions post, string text_key, bool upper)
        {
            var sujeto = post.Agent("other").Cast<MisionAgent>();
            sujeto.Hit();

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

            var outputables = new List<IOutputable>
            {
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
            };

            if (!sujeto.IsAlive) 
            {
                outputables.Add(new Pharagraph("muerte_pelea".trans()));
                outputables.Add(new Pharagraph("fin".trans()));
            }

            return new Output(outputables.ToArray());
        }

        private static Output aggression(PredefinedPostconditions post, string text_key)
        {
            var sujeto = post.Agent("other").Cast<SimonEstevez>();
            var extrano = post.Main.Cast<MisionAgent>();

            extrano.Hit();

            var part = new string[]
            {
                "head_part_1",
                "head_part_2",
                "head_part_3"
            }.Random().trans();

            var outputables = new List<IOutputable>
            {
                new Pharagraph(text_key.trans(part)),
                new Conversation().With(sujeto.TrueName, new string[]
                {
                    "aggression_celebration_1",
                    "aggression_celebration_2",
                    "aggression_celebration_3",
                    "aggression_celebration_4",
                }.Random().trans())
            };

            if (!extrano.IsAlive)
            {
                if(sujeto.IsRevelated)
                    post.World.State.Transite(States.Revelation);
                else
                    post.World.State.Transite(States.Mision);

                outputables.Add(new Pharagraph("muerte_extrano".trans()));
            }

            return new Output(outputables.ToArray());
        }
    }
}
