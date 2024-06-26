﻿using Stories.Builders;
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
using Logic;
using Mapping;

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
                .BeingRepeteable()
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
                        && !item.Cast<Frasco>().IsEmpty
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
                .Finish(),

                StoryletBuilder.Create("pulsarBoton")
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
                        && item.Id == "boton"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("pulsarBoton_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("cogerMesaPlegable")
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
                        && item.Id == "mesaSalon"
                        && pre.MainPlaceIsEnlighted()
                        && (pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id)));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("cogerMesaPlegable_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("mirarDebajoLitera")
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
                        && item.Id == "litera"
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var rejilla = post.World.Items.GetOne("rejilla");
                    var nowhere = post.World.Map.Get("nowhere");

                    if (nowhere.Items.Has(rejilla))
                        return Output.FromTexts("mirarDebajoLitera_something_text".trans());

                    return Output.FromTexts("mirarDebajoLitera_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("romperRejilla")
                .BeingRepeteable()
                .ForHumans()
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;
                    var rejilla = pre.World.Items.GetOne("rejilla");
                    var nowhere = pre.World.Map.Get("nowhere");

                    return pre.EveryoneConscious()
                        && (pre.PositionIs(Descriptor.MainRole, Position.Lying) || pre.PositionIs(Descriptor.MainRole, Position.Kneeing))
                        && pre.MainPlaceIsEnlighted()
                        && place.Id == "dormitorio"
                        && pre.Historic.HasHappened(new Snapshot("mirarDebajoLitera", main.Id, "litera"))
                        && nowhere.Items.Has(rejilla);
                })
                .WithInteraction((post) =>
                {
                    var item = post.World.Items.GetOne("rejilla");
                    var nowhere = post.World.Map.Get("nowhere");
                    var dormitorio = post.World.Map.Get("dormitorio");

                    var itemDescriptor = new ItemDescriptor(item);

                    nowhere.Items.Remove(item);
                    dormitorio.Items.Add(item);

                    return Output.FromTexts("romperRejilla_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("empujarLitera")
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
                        && pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id));
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("empujarLitera_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("untarteAceite")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && item.Id == "frasco"
                        && !item.Cast<Frasco>().IsEmpty
                        && pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var frasco = post.Item("thing").Cast<Frasco>();

                    frasco.Empty();

                    post.World.Knowledge.Add(Sentence.Build("Aceitado", main.Id));

                    return Output.FromTexts("untarteAceite_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("meterteRejillaFail")
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
                        && item.Id == "rejilla"
                        && pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("romperRejilla", main.Id))
                        && !pre.IsKnown("Aceitado", main.Id);
                })
                .WithInteraction((post) =>
                {
                    var item = post.Item("thing");
                    var itemDescriptor = new ItemDescriptor(item);

                    return Output.FromTexts("meterteRejillaFail_text".trans(itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("meterteRejilla")
                .BeingGlobalSingle()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && (pre.PositionIs(Descriptor.MainRole, Position.Lying) || pre.PositionIs(Descriptor.MainRole, Position.Kneeing))
                        && item.Id == "rejilla"
                        && pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("romperRejilla", main.Id))
                        && pre.IsKnown("Aceitado", main.Id);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.Item("thing");
                    var frasco = post.World.Items.GetOne("frasco");

                    var itemDescriptor = new ItemDescriptor(item);

                    var dormitorio = post.MainPlace;
                    var otroLavabo = post.World.Map.Get("otroLavabo");
                    post.World.Map.Connect(dormitorio, otroLavabo, Direction.East_West);
                    post.World.Map.Move(main, dormitorio, otroLavabo, post.World.Items);

                    return Output.FromTexts("meterteRejilla_text".trans(itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("sentarteSilla")
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
                        && item.Id == "silla"
                        && pre.MainPlaceIsEnlighted()
                        && pre.Historic.HasHappened(new Snapshot("mirar_item", main.Id, item.Id));
                })
                .WithInteraction((post) =>
                {
                    var silla = post.Item("thing");
                    post.MainPlace.Items.Remove(silla);

                    var nowhere = post.World.Map.Get("nowhere");
                    nowhere.Items.Add(silla);

                    var sillaRota = post.World.Items.GetOne("sillaRota");
                    nowhere.Items.Remove(sillaRota);
                    post.MainPlace.Items.Add(sillaRota);
                    post.MainPlace.Items.Hide(sillaRota);

                    post.Main.Position.Machine.Transite(Position.Lying);

                    return Output.FromTexts("sentarteSilla_text".trans());
                })
                    .WithSubinteraction((post) =>
                    {
                        post.World.State.Transite(States.Revelation);

                        var nowhere = post.World.Map.Get("nowhere");
                        var lavabo = post.World.Map.Get("lavabo");
                        var otroLavabo = post.World.Map.Get("otroLavabo");
                        var espejo = post.World.Items.GetOne("espejo");
                        var espejoConsciente = post.World.Items.GetOne("espejoConsciente");

                        nowhere.Items.Remove(espejoConsciente);
                        lavabo.Items.Remove(espejo);
                        otroLavabo.Items.Remove(espejo);

                        nowhere.Items.Add(espejo);
                        lavabo.Items.Add(espejoConsciente);
                        otroLavabo.Items.Add(espejoConsciente);
                        lavabo.Items.Hide(espejoConsciente);
                        otroLavabo.Items.Hide(espejoConsciente);

                        var comandante = post.World.Agents.GetOne("comandante");
                        comandante.Status.Machine.Transite(Status.Unconscious);

                        var natalia = post.World.Agents.GetOne("natalia");
                        natalia.Status.Machine.Transite(Status.Conscious);

                        var sujeto = post.Main.Cast<SimonEstevez>();

                        var sujetoConversation = new Conversation()
                            .With(sujeto.TrueName, "sentarteSilla_revelacion_text_1".trans())
                            .With(sujeto.TrueName, "sentarteSilla_revelacion_text_2".trans())
                            .With(sujeto.TrueName, "sentarteSilla_revelacion_text_3".trans());

                        sujeto.Revelate();

                        var simonCoversation = new Conversation()
                            .With(sujeto.TrueName, "sentarteSilla_revelacion_text_4".trans());

                        return new Output(sujetoConversation, simonCoversation);
                    })
                            .WithDriver(Descriptor.MainRole)
                            .Build()
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish()
                );
        }
    }
}
