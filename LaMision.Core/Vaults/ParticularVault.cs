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

                    var text = new Pharagraph(
                        "acercarTarjetaPuerta_text".trans(
                            tarjetaDescriptor.ArticledName(true),
                            doorDescriptor.ArticledName(true)));

                    var openResult = door!.Openable.Open(tarjeta);
                    var openText = openResult switch
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
                    };

                    var view = door.Connect(post.World);

                    return new Output(
                        text, 
                        new Pharagraph(openText), 
                        new Pharagraph(view));
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
                    var place = pre.World.Map.GetUbication(main);

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
                .Finish()
                );
        }
    }
}
