using Stories.Builders;
using Stories;
using Outputer;
using Languager.Extensions;
using Rolling;
using LaMision.Core.Elements;
using Items.Extensions;
using Items;
using ItemsLang;
using Rand;
using Agents.Extensions;
using Agents;
using AgentBody;
using ClimaticsLang;

namespace LaMision.Core.Vaults
{
    public static class ParticularVault
    {
        public static StoriesVault Get()
        {
            return new StoriesVault(
                StoryletBuilder.Create("abrirEscotilla")
                .BeingSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneStanding()
                        && pre.EveryoneConscious()
                        && pre.MainPlaceIsEnlighted()
                        && pre.Item("thing").Id == "escotilla"
                        && pre.Historic.HasHappened(new Snapshot("mirar_item", pre.Main.Id, "escotilla"));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("abrirEscotilla_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("acercarTarjetaPuerta")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("tarjeta", "door")
                .WithItemsScope()
                .WithEnvPreconditions((pre) => pre.IsState(States.Mision))
                .WithPreconditions((pre) =>
                {
                    var door = pre.Item("door");

                    return pre.EveryoneStanding()
                        && pre.EveryoneConscious()
                        && pre.MainPlaceIsEnlighted()
                        && pre.Item("tarjeta") is Tarjeta
                        && door is Puerta
                        && door.Cast<IOpenable>().Openable.IsClosed
                        && pre.RoleOwns(Descriptor.MainRole, "tarjeta")
                        && pre.MainPlace.Items.Has(door)
                        && pre.Historic.HasHappened(new Snapshot("mirar_item", pre.Main.Id, door.Id));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var tarjeta = post.Item("tarjeta") as Tarjeta;
                    var door = post.Item("door") as Puerta;

                    var tarjetaDescriptor = new ItemDescriptor(tarjeta!);
                    var doorDescriptor = new ItemDescriptor(door!);

                    var texts = new List<string> 
                    {
                        "acercarTarjetaPuerta_text".trans(
                        tarjetaDescriptor.ArticledName(true),
                        doorDescriptor.ArticledName(true))
                    };

                    var openResult = door!.Openable.Open(tarjeta);

                    texts.Add(openResult switch
                    {
                        OpenResult.Success => new string[]
                        {
                            "acercarTarjetaPuerta_sucess_1",
                            "acercarTarjetaPuerta_sucess_2",
                            "acercarTarjetaPuerta_sucess_3"
                        }.Random().trans(),
                        OpenResult.InvalidKey => "acercarTarjetaPuerta_invalidKey".trans(),
                        OpenResult.MissingKey => throw new NotSupportedException(),
                        OpenResult.UnneededKey => throw new NotSupportedException(),
                        OpenResult.NotNeeded => throw new NotSupportedException(),
                        _ => throw new NotSupportedException()
                    });

                    if(openResult == OpenResult.Success)
                        texts.Add(door.Connect(post.World));

                    return Output.FromTexts(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("cogerTraje")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "trajePlastico"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("cogerTraje_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("sentarSofa")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "sofa"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("sentarSofa_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("usarVater")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "vater"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("usarVater_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("usarLavadero")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "lavadero"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("usarLavadero_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("usarLitera")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "litera"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("usarLitera_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("beberFrasco")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && item.Id == "frasco"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("beberFrasco_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("mirarDebajoSofa")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");
                    
                    return pre.EveryoneConscious()
                        && (pre.PositionIs(Descriptor.MainRole, Position.Lying) || pre.PositionIs(Descriptor.MainRole, Position.Kneeing))
                        && item.Id == "sofa"
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.Item("thing");
                    var tarjetaNaranja = post.World.Items.GetOne("tarjetaNaranja");
                    var nowhere = post.World.Map.Get("nowhere");

                    if (nowhere.Items.Has(tarjetaNaranja))
                        return Output.FromTexts("mirarDebajoSofa_something_text".trans());

                    return Output.FromTexts("mirarDebajoSofa_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("cogerTarjetaNaranja")
                .BeingRepeteable()
                .ForHumans()
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;
                    var tarjetaNaranja = pre.World.Items.GetOne("tarjetaNaranja");
                    var nowhere = pre.World.Map.Get("nowhere");

                    return pre.EveryoneConscious()
                        && (pre.PositionIs(Descriptor.MainRole, Position.Lying) || pre.PositionIs(Descriptor.MainRole, Position.Kneeing))
                        && pre.MainPlaceIsEnlighted()
                        && place.Id == "salon"
                        && pre.Historic.HasHappened(new Snapshot("mirarDebajoSofa", main.Id, "sofa"))
                        && nowhere.Items.Has(tarjetaNaranja);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.World.Items.GetOne("tarjetaNaranja");
                    var nowhere = post.World.Map.Get("nowhere");

                    var itemDescriptor = new ItemDescriptor(item);

                    var baggingResult = main.Cast<ICarrier>().Carrier.Take(item, post.World.Items);
                    if (!baggingResult.HasBag)
                        return Output.FromTexts("coger_nobag".trans(main.Name, itemDescriptor.ArticledName(true)));

                    if (baggingResult.Addition == ItemAddition.Big)
                        return Output.FromTexts("coger_big".trans(main.Name, itemDescriptor.ArticledName(true)));

                    if (baggingResult.Addition == ItemAddition.Heavy)
                        return Output.FromTexts("coger_heavy".trans(main.Name, itemDescriptor.ArticledName(true)));

                    var removed = nowhere.Items.Remove(item);

                    return Output.FromTexts("coger_good".trans(main.Name, itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish()
                );
        }
    }
}
