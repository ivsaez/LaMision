using AgentBody;
using Agents;
using Agents.Extensions;
using ClimaticsLang;
using Items;
using ItemsLang;
using LaMision.Core.Elements;
using Languager.Extensions;
using Mapping;
using MappingLang;
using Outputer;
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
            var mirar_mapped = StoryletBuilder.Create("mirar_mapped")
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
                .Finish();

            var mirar_item = StoryletBuilder.Create("mirar_item")
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

                    return Output.FromTexts(itemDescriptor.Description);
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();

            var ir = StoryletBuilder.Create("ir")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("place")
                .WithMappedsScope()
                .WithPreconditions((pre) =>
                    pre.EveryoneConscious()
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
                .Finish();

            var coger = StoryletBuilder.Create("coger")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var main = pre.Roles.Get<MisionAgent>(Descriptor.MainRole);
                    var item = pre.Roles.Get<IItem>("thing");
                    var place = pre.World.Map.GetUbication(main);

                    return pre.EveryoneConscious()
                        && main.Position.Machine.CurrentState == Position.Standing
                        && main is ICarrier
                        && place.Items.Has(item)
                        && item is not IFurniture
                        && pre.MainPlaceIsEnlighted()
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

                    place.Items.Remove(item);
                    return Output.FromTexts("coger_good".trans(main.Name, itemDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();

            var dejar = StoryletBuilder.Create("dejar")
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
                .Finish();

            var levantarse = StoryletBuilder.Create("levantarse")
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
                    Console.WriteLine(done);

                    return Output.FromTexts("levantarse_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();

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

            //var pedirse = StoryletBuilder.Create("pedirse")
            //    .ForMachines()
            //    .WithAgentsScope()
            //    .WithPreconditions((pre) => pre.EveryoneConscious())
            //    .WithInteraction((world, roles) =>
            //    {
            //        var main = roles.Get<MisionAgent>(Descriptor.MainRole);

            //        return new Output(
            //            new Pharagraph("pedirse_text".trans(main.Name)),
            //            new Conversation().With(main.Name, "pedirse_conversation".trans())
            //            );
            //    })
            //        .WithDriver(Descriptor.MainRole)
            //        .SetAsRoot()
            //    .Finish();

            //var sacamoco = StoryletBuilder.Create("sacamoco")
            //    .ForMachines()
            //    .WithAgentsScope()
            //    .WithPreconditions((pre) => pre.EveryoneConscious())
            //    .WithInteraction((world, roles) =>
            //    {
            //        var main = roles.Get<MisionAgent>(Descriptor.MainRole);

            //        return Output.FromTexts("sacamoco_text".trans(main.Name));
            //    })
            //        .WithDriver(Descriptor.MainRole)
            //        .SetAsRoot()
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
                mirar_mapped,
                mirar_item,
                ir,
                coger,
                dejar,
                levantarse);
        }
    }
}
