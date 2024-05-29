using Agents;
using Agents.Extensions;
using LaMision.Core.Elements;
using Languager.Extensions;
using Outputer;
using Rolling;
using Stories;
using Stories.Builders;

namespace LaMision.Core.Vaults
{
    public static class EndingsVault
    {
        public static StoriesVault Get()
        {
            return new StoriesVault(
                StoryletBuilder.Create("ending1")
                .BeingGlobalSingle()
                .ForMachines()
                .WithEnvPreconditions(pre => (pre.IsHour(21) || pre.IsHour(22) || pre.IsHour(23)) && pre.IsState(States.Mision))
                .WithPreconditions((pre) => true)
                .WithInteraction((post) =>
                {
                    var sujeto = post.World.Agents.GetOne("sujeto").Cast<SimonEstevez>();
                    var comandante = post.World.Agents.GetOne("comandante").Cast<MisionAgent>();
                    var natalia = post.World.Agents.GetOne("natalia").Cast<MisionAgent>();
                    var extrano = post.World.Agents.GetOne("extrano").Cast<MisionAgent>();

                    sujeto.Status.Machine.Transite(Status.Dead);
                    comandante.Status.Machine.Transite(Status.Dead);
                    natalia.Status.Machine.Transite(Status.Dead);
                    extrano.Status.Machine.Transite(Status.Dead);

                    var texts = new List<IOutputable>
                    {
                        new Pharagraph("ending_shared_text_1".trans()),
                        new Pharagraph("ending_shared_text_2".trans()),
                        new Pharagraph("ending_shared_text_3".trans()),
                        new Pharagraph("ending_shared_text_4".trans()),
                        new Pharagraph("ending_shared_text_5".trans()),
                        new Pharagraph("ending_shared_text_6".trans()),

                        new Conversation().With("Soldado", "ending_shared_text_7".trans()),

                        new Pharagraph("ending_shared_text_8".trans()),

                        new Conversation().With(sujeto.TrueName, "ending_shared_text_9".trans()),
                    };

                    if (post.Historic.HasGloballyHappened("tirarPalanca"))
                    {
                        texts.Add(new Pharagraph("ending_shared_text_botones_1".trans()));
                        texts.Add(new Conversation().With("Otro soldado", "ending_shared_text_botones_2".trans()));
                        texts.Add(new Conversation().With("Soldado", "ending_shared_text_botones_3".trans()));
                    }

                    texts.Add(new Pharagraph("ending_shared_text_10".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_11".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_12".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_13".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_14".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_15".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_16".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_17".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_18".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_19".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_20".trans()));

                    texts.Add(new Conversation().With("Desconocido", "ending1_text_1".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending1_text_2".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending1_text_3".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending1_text_4".trans()));
                    texts.Add(new Pharagraph("ending1_text_5".trans()));
                    texts.Add(new Pharagraph("ending1_text_6".trans()));

                    texts.Add(new Pharagraph("fin".trans()));

                    return new Output(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("ending2")
                .BeingGlobalSingle()
                .ForMachines()
                .WithEnvPreconditions(pre => (pre.IsHour(21) || pre.IsHour(22) || pre.IsHour(23)) && pre.IsState(States.Revelation))
                .WithPreconditions((pre) => pre.World.Agents.GetOne("extrano").Cast<MisionAgent>().IsAlive)
                .WithInteraction((post) =>
                {
                    var sujeto = post.World.Agents.GetOne("sujeto").Cast<SimonEstevez>();
                    var comandante = post.World.Agents.GetOne("comandante").Cast<MisionAgent>();
                    var natalia = post.World.Agents.GetOne("natalia").Cast<MisionAgent>();
                    var extrano = post.World.Agents.GetOne("extrano").Cast<MisionAgent>();

                    sujeto.Status.Machine.Transite(Status.Dead);
                    comandante.Status.Machine.Transite(Status.Dead);
                    natalia.Status.Machine.Transite(Status.Dead);
                    extrano.Status.Machine.Transite(Status.Dead);

                    var texts = new List<IOutputable>
                    {
                        new Pharagraph("ending_shared_text_1".trans()),
                        new Pharagraph("ending_shared_text_2".trans()),
                        new Pharagraph("ending_shared_text_3".trans()),
                        new Pharagraph("ending_shared_text_4".trans()),
                        new Pharagraph("ending_shared_text_5".trans()),
                        new Pharagraph("ending_shared_text_6".trans()),

                        new Conversation().With("Soldado", "ending_shared_text_7".trans()),

                        new Pharagraph("ending_shared_text_8".trans()),

                        new Conversation().With(sujeto.TrueName, "ending_shared_text_9".trans()),
                    };

                    if (post.Historic.HasGloballyHappened("tirarPalanca"))
                    {
                        texts.Add(new Pharagraph("ending_shared_text_botones_1".trans()));
                        texts.Add(new Conversation().With("Otro soldado", "ending_shared_text_botones_2".trans()));
                        texts.Add(new Conversation().With("Soldado", "ending_shared_text_botones_3".trans()));
                    }

                    texts.Add(new Pharagraph("ending_shared_text_10".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_11".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_12".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_13".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_14".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_15".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_16".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_17".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_18".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_19".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_20".trans()));

                    texts.Add(new Conversation().With("Desconocido", "ending2_text_1".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending2_text_2".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending2_text_3".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending2_text_4".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending2_text_5".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending2_text_6".trans()));
                    texts.Add(new Pharagraph("ending2_text_7".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending2_text_8".trans()));
                    texts.Add(new Pharagraph("ending2_text_9".trans()));

                    texts.Add(new Pharagraph("fin".trans()));

                    return new Output(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("ending3")
                .BeingGlobalSingle()
                .ForMachines()
                .WithEnvPreconditions(pre => (pre.IsHour(21) || pre.IsHour(22) || pre.IsHour(23)) && pre.IsState(States.Revelation))
                .WithPreconditions((pre) => !pre.World.Agents.GetOne("extrano").Cast<MisionAgent>().IsAlive)
                .WithInteraction((post) =>
                {
                    var sujeto = post.World.Agents.GetOne("sujeto").Cast<SimonEstevez>();
                    var comandante = post.World.Agents.GetOne("comandante").Cast<MisionAgent>();
                    var natalia = post.World.Agents.GetOne("natalia").Cast<MisionAgent>();
                    var extrano = post.World.Agents.GetOne("extrano").Cast<MisionAgent>();

                    sujeto.Status.Machine.Transite(Status.Dead);
                    comandante.Status.Machine.Transite(Status.Dead);
                    natalia.Status.Machine.Transite(Status.Dead);
                    extrano.Status.Machine.Transite(Status.Dead);

                    var texts = new List<IOutputable>
                    {
                        new Pharagraph("ending_shared_text_1".trans()),
                        new Pharagraph("ending_shared_text_2".trans()),
                        new Pharagraph("ending_shared_text_3".trans()),
                        new Pharagraph("ending_shared_text_4".trans()),
                        new Pharagraph("ending_shared_text_5".trans()),
                        new Pharagraph("ending_shared_text_6".trans()),

                        new Conversation().With("Soldado", "ending_shared_text_7".trans()),

                        new Pharagraph("ending_shared_text_8".trans()),

                        new Conversation().With(sujeto.TrueName, "ending_shared_text_9".trans()),
                    };

                    if (post.Historic.HasGloballyHappened("tirarPalanca"))
                    {
                        texts.Add(new Pharagraph("ending_shared_text_botones_1".trans()));
                        texts.Add(new Conversation().With("Otro soldado", "ending_shared_text_botones_2".trans()));
                        texts.Add(new Conversation().With("Soldado", "ending_shared_text_botones_3".trans()));
                    }

                    texts.Add(new Pharagraph("ending_shared_text_10".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_11".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_12".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_13".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_14".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_15".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_16".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_17".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_18".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_19".trans()));
                    texts.Add(new Pharagraph("ending_shared_text_20".trans()));

                    texts.Add(new Conversation().With("Desconocido", "ending3_text_1".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending3_text_2".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending3_text_3".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending3_text_4".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending3_text_5".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending3_text_6".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending3_text_7".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending3_text_8".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending3_text_9".trans()));
                    texts.Add(new Conversation().With(sujeto.TrueName, "ending3_text_10".trans()));
                    texts.Add(new Conversation().With("Desconocido", "ending3_text_11".trans()));
                    texts.Add(new Pharagraph("ending3_text_12".trans()));

                    texts.Add(new Pharagraph("fin".trans()));

                    return new Output(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish()
            );
        }
    }
}
