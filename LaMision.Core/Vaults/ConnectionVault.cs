using Agents;
using Items.Extensions;
using ItemsLang;
using LaMision.Core.Elements;
using Languager.Extensions;
using Outputer;
using Rolling;
using Stories;
using Stories.Builders;

namespace LaMision.Core.Vaults
{
    public static class ConnectionVault
    {
        public static StoriesVault Get()
        {
            return new StoriesVault(
                StoryletBuilder.Create("tirarPalanca")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var item = pre.Item("thing");
                    var cableNegro = pre.World.Items.GetOne("cableNegro").Cast<Cable>();
                    var cableBlanco = pre.World.Items.GetOne("cableBlanco").Cast<Cable>();
                    var cableGris = pre.World.Items.GetOne("cableGris").Cast<Cable>();

                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing)
                        && item.Id == "palanca"
                        && cableNegro.IsConnected
                        && cableBlanco.IsConnected
                        && cableGris.IsConnected
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    return Output.FromTexts("tirarPalanca_text".trans());
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                 StoryletBuilder.Create("connectCable")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("cable", "other")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var cable = pre.Item("cable");
                    var other = pre.Item("other");

                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing)
                        && cable is Cable
                        && other is Cable
                        && !cable.Cast<Cable>().IsConnected
                        && !other.Cast<Cable>().IsConnected
                        && (cable.Id == "cableNegro" || cable.Id == "cableGris" || cable.Id == "cableBlanco")
                        && (other.Id == "cableAzul" || other.Id == "cableRojo" || other.Id == "cableAmarillo")
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var cable = post.Item("cable").Cast<Cable>();
                    var other = post.Item("other").Cast<Cable>();

                    cable.Connect(other);
                    other.Connect(cable);

                    var cableDescriptor = new ItemDescriptor(cable);
                    var otherDescriptor = new ItemDescriptor(other);

                    return Output.FromTexts("connectCable_text".trans(cableDescriptor.ArticledName(true), otherDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),

                 StoryletBuilder.Create("disconnectCable")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("cable", "other")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var cable = pre.Item("cable");
                    var other = pre.Item("other");

                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing)
                        && cable is Cable
                        && other is Cable
                        && cable.Cast<Cable>().IsConnected
                        && other.Cast<Cable>().IsConnected
                        && cable.Cast<Cable>().Connection == other.Id
                        && (cable.Id == "cableNegro" || cable.Id == "cableGris" || cable.Id == "cableBlanco")
                        && (other.Id == "cableAzul" || other.Id == "cableRojo" || other.Id == "cableAmarillo")
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var cable = post.Item("cable").Cast<Cable>();
                    var other = post.Item("other").Cast<Cable>();

                    cable.UnConnect();
                    other.UnConnect();

                    var cableDescriptor = new ItemDescriptor(cable);
                    var otherDescriptor = new ItemDescriptor(other);

                    return Output.FromTexts("disconnectCable_text".trans(cableDescriptor.ArticledName(true), otherDescriptor.ArticledName(true)));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish(),
                buildPulsarInterruptor(0),
                buildPulsarInterruptor(1),
                buildPulsarInterruptor(2),
                buildPulsarInterruptor(3),
                buildPulsarInterruptor(4),
                buildPulsarInterruptor(5),
                buildPulsarInterruptor(6),
                buildPulsarInterruptor(7),
                buildPulsarInterruptor(8),
                buildPulsarInterruptor(9),
                buildDesactivarInterruptor(0),
                buildDesactivarInterruptor(1),
                buildDesactivarInterruptor(2),
                buildDesactivarInterruptor(3),
                buildDesactivarInterruptor(4),
                buildDesactivarInterruptor(5),
                buildDesactivarInterruptor(6),
                buildDesactivarInterruptor(7),
                buildDesactivarInterruptor(8),
                buildDesactivarInterruptor(9)
            );
        }

        private static Storylet buildPulsarInterruptor(int index)
        {
            return StoryletBuilder.Create($"pulsarInterruptor{index}")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var item = pre.Item("thing");
                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing)
                        && item is Interruptores
                        && !item.Cast<Interruptores>().IsPulsed(index)
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var item = post.Item("thing");
                    item.Cast<Interruptores>().Pulse(index);

                    var interruptorNumber = (index + 1).ToString();
                    return Output.FromTexts("pulsarInterruptor_text".trans(interruptorNumber));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();
        }
        private static Storylet buildDesactivarInterruptor(int index)
        {
            return StoryletBuilder.Create($"desactivarInterruptor{index}")
                .BeingRepeteable()
                .ForHumans()
                .WithDescriptor("thing")
                .WithItemsScope()
                .WithPreconditions((pre) =>
                {
                    var item = pre.Item("thing");

                    return pre.EveryoneConscious()
                        && pre.PositionIs(Descriptor.MainRole, Position.Standing)
                        && item is Interruptores
                        && item.Cast<Interruptores>().IsPulsed(index)
                        && pre.MainPlaceIsEnlighted();
                })
                .WithInteraction((post) =>
                {
                    var item = post.Item("thing");
                    item.Cast<Interruptores>().UnPulse(index);

                    var interruptorNumber = (index + 1).ToString();
                    return Output.FromTexts("desactivarInterruptor_text".trans(interruptorNumber));
                })
                    .WithDriver(Descriptor.MainRole)
                    .SetAsRoot()
                .Finish();
        }
    }
}
