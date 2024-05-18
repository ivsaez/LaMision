using AgentBody;
using Agents;
using Agents.Extensions;
using ClimaticsLang;
using Items;
using Items.Extensions;
using ItemsLang;
using LaMision.Core.Elements;
using Languager.Extensions;
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
    public static class BasicVault
    {
        public static StoriesVault Get()
        {
            //var saludo = StoryletBuilder.Create("saludo")
            //    .BeingSingle()
            //    .ForHumans()
            //    .WithDescriptor("saluted")
            //    .WithAgentsScope()
            //    .WithPreconditions((pre) => pre.EveryoneConscious() && pre.EverythingInMainPlace())
            //    .WithInteraction((world, roles) =>
            //    {
            //        var main = roles.Get<MisionAgent>(Descriptor.MainRole);
            //        var saluted = roles.Get<MisionAgent>("saluted");

            //        return Output.FromSpeech(main.Name, "saludo_text".trans(saluted.Name));
            //    })
            //        .WithSubinteraction((world, roles) =>
            //        {
            //            var main = roles.Get<MisionAgent>(Descriptor.MainRole);
            //            var saluted = roles.Get<MisionAgent>("saluted");

            //            return Output.FromSpeech(saluted.Name, "respuesta_text".trans(main.Name));
            //        })
            //        .WithDriver("saluted")
            //        .Build()
            //    .WithDriver(Descriptor.MainRole)
            //    .SetAsRoot()
            //    .Finish();

            //var estornudo = StoryletBuilder.Create("estornudo")
            //    .ForHumans()
            //    .WithAgentsScope()
            //    .WithPreconditions((pre) => pre.EveryoneConscious())
            //    .WithInteraction((world, roles) =>
            //    {
            //        var main = roles.Get<MisionAgent>(Descriptor.MainRole);

            //        return Output.FromTexts("estornudo_1_text".trans(main.Name));
            //    })
            //        .WithDriver(Descriptor.MainRole)
            //        .WithSubinteraction((world, roles) =>
            //        {
            //            var main = roles.Get<MisionAgent>(Descriptor.MainRole);

            //            return Output.FromTexts("estornudo_2_text".trans(main.Name));
            //        })
            //            .Build()
            //        .WithSubinteraction((world, roles) =>
            //        {
            //            var main = roles.Get<MisionAgent>(Descriptor.MainRole);

            //            return Output.FromTexts("estornudo_3_text".trans(main.Name));
            //        })
            //            .Build()
            //        .SetAsRoot()
            //    .Finish();

            return new StoriesVault(
                StoryletBuilder.Create("mirar_mapped")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("place")
                .WithMappedsScope()
                .WithPreconditions((pre) => pre.EveryoneConscious() && pre.RoleInPlace(Descriptor.MainRole, "place"))
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var origin = post.MainPlace;

                    var mappedDescriptor = new MappedDescriptor(origin);

                    var climaticsDescriptor = new TimeDescriptor(post.World.Time);

                    return Output.FromTexts(mappedDescriptor.GetEntireDescription(
                            main,
                            post.World.Existents,
                            post.World.Time.IsLight,
                            climaticsDescriptor.RandomOutsideDescription));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("mirar_item")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && (pre.EverythingInMainPlace() || pre.RoleOwns(Descriptor.MainRole, "thing"))
                        && (pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id))
                            || pre.HasHappened("dejar", Descriptor.MainRole, "thing"));
                })
                .WithInteraction((post) =>
                {
                    var item = post.Item("thing");

                    var itemDescriptor = new ItemDescriptor(item);

                    var texts = new List<string>
                    {
                        itemDescriptor.Description
                    };

                    if(item is IOpenable)
                    {
                        var openableDescriptor = new OpenableDescriptor(item.Cast<IOpenable>().Openable);
                        texts.Add(openableDescriptor.GetTargetDescription(item.Cast<IArticled>().Articler));
                    }

                    if(item is IContainer)
                    {
                        if(item is not IOpenable || item.Cast<IOpenable>().Openable.IsOpened)
                        {
                            var inventoryDescriptor = new InventoryDescriptor(item.Cast<IContainer>().Inventory);
                            texts.Add(inventoryDescriptor.GetObservablesDescription(post.World.Items));
                        }
                    }

                    return Output.FromTexts(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("ir")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("place")
                .WithMappedsScope()
                .WithPreconditions((pre) =>
                    pre.EveryoneConscious()
                    && pre.EveryoneStanding()
                    && !pre.RoleInPlace(Descriptor.MainRole, "place")
                    && pre.IsExit("place"))
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var place = post.MainPlace;
                    var destination = post.Mapped("place");

                    var movementResult = post.World.Map.Move(main, place, destination, post.World.Items);

                    var mappedDescriptor = new MappedDescriptor(destination);

                    if (movementResult.Outcome == MovementOutcome.BlockingDoor)
                        return Output.FromTexts("ir_door".trans(main.Name, mappedDescriptor.ArticledName));

                    return Output.FromTexts("ir".trans(main.Name, mappedDescriptor.ArticledName));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("coger")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");
                    var place = pre.MainPlace;

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && main is ICarrier
                        && item is not IFurniture
                        && pre.MainPlaceIsEnlighted()
                        && !pre.RoleOwns(Descriptor.MainRole, "thing")
                        && !main.Cast<ICarrier>().Carrier.GetCarrieds(pre.World.Items).Back!.Equals(item)
                        && (pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id))
                            || pre.HasHappened("dejar", Descriptor.MainRole, "thing"));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.Item("thing");
                    var place = post.MainPlace;

                    var itemDescriptor = new ItemDescriptor(item);

                    var baggingResult = main.Cast<ICarrier>().Carrier.Take(item, post.World.Items);
                    if (!baggingResult.HasBag)
                        return Output.FromTexts("coger_nobag".trans(main.Name, itemDescriptor.ArticledName(true)));

                    if (baggingResult.Addition == ItemAddition.Big)
                        return Output.FromTexts("coger_big".trans(main.Name, itemDescriptor.ArticledName(true)));

                    if (baggingResult.Addition == ItemAddition.Heavy)
                        return Output.FromTexts("coger_heavy".trans(main.Name, itemDescriptor.ArticledName(true)));

                    var removed = place.Items.Remove(item);
                    if (!removed)
                    {
                        foreach (var thing in place.Items.AllAccessible(post.World.Items))
                        {
                            if (thing is IContainer)
                            {
                                removed = thing.Cast<IContainer>().Inventory.Remove(item);
                                if(removed) break;
                            }
                        }
                    }

                    return Output.FromTexts("coger_good".trans(main.Name, itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("dejar")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && pre.RoleOwns(Descriptor.MainRole, "thing")
                        && !main.Cast<ICarrier>().Carrier.GetCarrieds(pre.World.Items).Back!.Equals(item);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.Item("thing");
                    var place = post.MainPlace;

                    var itemDescriptor = new ItemDescriptor(item);

                    main.Cast<ICarrier>().Carrier.Leave(item, post.World.Items);
                    place.Items.Add(item);

                    return Output.FromTexts("dejar".trans(main.Name, itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("dejarEn")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing", "recipient")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var item = pre.Item("thing");
                    var recipient = pre.Item("recipient");
                    var place = pre.MainPlace;

                    return pre.EveryoneConscious()
                        && pre.MainPlaceIsEnlighted()
                        && pre.RoleOwns(Descriptor.MainRole, "thing")
                        && recipient is IContainer
                        && pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id))
                        && !main.Cast<ICarrier>().Carrier.GetCarrieds(pre.World.Items).Back!.Equals(recipient)
                        && !main.Cast<ICarrier>().Carrier.GetCarrieds(pre.World.Items).Back!.Equals(item);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var item = post.Item("thing");
                    var recipient = post.Item("recipient");

                    var itemDescriptor = new ItemDescriptor(item);
                    var recipientDescriptor = new ItemDescriptor(recipient);

                    if (recipient is IOpenable && recipient.Cast<IOpenable>().Openable.IsClosed)
                        return Output.FromTexts("dejarEn_closed".trans(recipientDescriptor.ArticledName(true)));

                    var addition = recipient.Cast<IContainer>().Inventory.Add(item, post.World.Items);

                    if(addition == ItemAddition.Heavy)
                        return Output.FromTexts("dejarEn_heavy".trans(itemDescriptor.ArticledName(true), recipientDescriptor.ArticledName(true)));

                    if (addition == ItemAddition.Big)
                        return Output.FromTexts("dejarEn_big".trans(itemDescriptor.ArticledName(true), recipientDescriptor.ArticledName(true)));

                    main.Cast<ICarrier>().Carrier.Leave(item, post.World.Items);

                    return Output.FromTexts("dejarEn_success".trans(itemDescriptor.ArticledName(true), recipientDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("levantarse")
                .BeingRepeteable()
                .ForHumans()
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneConscious()
                        && (pre.PositionIs(Descriptor.MainRole, Position.Lying)
                        || pre.PositionIs(Descriptor.MainRole, Position.Sitting)
                        || pre.PositionIs(Descriptor.MainRole, Position.Kneeing));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var done = main.Position.Machine.Transite(Position.Standing);

                    return Output.FromTexts("levantarse_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("agacharse")
                .BeingRepeteable()
                .ForHumans()
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var done = main.Position.Machine.Transite(Position.Kneeing);

                    return Output.FromTexts("agacharse_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("tumbarse")
                .BeingRepeteable()
                .ForHumans()
                .WithAgentsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing);
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var done = main.Position.Machine.Transite(Position.Lying);

                    return Output.FromTexts("tumbarse_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("abrir")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("openable")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Main;
                    var place = pre.MainPlace;

                    return pre.EveryoneStanding()
                        && pre.EverythingInMainPlace()
                        && pre.MainPlaceIsEnlighted()
                        && pre.EveryoneConscious()
                        && pre.Item("openable") is not Puerta
                        && pre.Item("openable") is IOpenable
                        && pre.Item("openable").Cast<IOpenable>().Openable.IsClosed
                        && pre.Historic.HasHappened(new Snapshot("mirar_mapped", main.Id, place.Id));
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var openable = post.Item("openable") as IOpenable;

                    var openableDescriptor = new ItemDescriptor(openable!);

                    var texts = new List<string>
                    {
                        "abrir_text".trans(
                            openableDescriptor.ArticledName(true))
                    };

                    var openResult = openable!.Openable.Open();
                    texts.Add(openResult switch
                    {
                        OpenResult.Success => new string[]
                        {
                            "abrir_sucess"
                        }.Random().trans(openableDescriptor.ArticledName(true)),
                        OpenResult.InvalidKey => "abrir_invalidKey".trans(),
                        OpenResult.MissingKey => throw new NotSupportedException(),
                        OpenResult.UnneededKey => throw new NotSupportedException(),
                        OpenResult.NotNeeded => throw new NotSupportedException(),
                        _ => throw new NotSupportedException()
                    });

                    if(openable is IContainer)
                    {
                        var inventoryDescriptor = new InventoryDescriptor(openable.Cast<IContainer>().Inventory);
                        texts.Add(inventoryDescriptor.GetObservablesDescription(post.World.Items));
                    }

                    return Output.FromTexts(texts.ToArray());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                StoryletBuilder.Create("cerrar")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("openable")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    return pre.EveryoneStanding()
                        && pre.EverythingInMainPlace()
                        && pre.MainPlaceIsEnlighted()
                        && pre.EveryoneConscious()
                        && pre.Item("openable") is not Puerta
                        && pre.Item("openable") is IOpenable
                        && pre.Item("openable").Cast<IOpenable>().Openable.IsOpened;
                })
                .WithInteraction((post) =>
                {
                    var main = post.Main;
                    var openable = post.Item("openable") as IOpenable;

                    var openableDescriptor = new ItemDescriptor(openable!);

                    openable!.Openable.Close();

                    return Output.FromTexts("cerrar_text".trans(
                            openableDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish()
                );
        }
    }
}
