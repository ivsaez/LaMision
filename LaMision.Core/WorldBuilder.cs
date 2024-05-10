using LaMision.Core.Elements;
using Agents;
using Items;
using ItemTypes;
using Mapping;
using Outputer;
using StateMachine;
using Worlding;

namespace LaMision.Core
{
    public static class WorldBuilder
    {
        public static World Build()
        {
            var world = new World(MachineBuilder.Create()
                .WithState("Initial")
                .EndState()
                .Build());

            world.Time.IncreaseHours(10);

            var bedRoom = new MisionMapped("bedRoom", Externality.Internal, Genere.Masculine, Number.Singular);
            var corridor = new MisionMapped("corridor", Externality.Internal, Genere.Masculine, Number.Singular);

            world.Map.Add(bedRoom);
            world.Map.Add(corridor);

            world.Map.Connect(bedRoom, corridor, Direction.East_West);

            var todi = new MisionAgent("todi", "Todivio", "Belmonte", Importance.Main);
            todi.BecomeHuman();
            var crispin = new MisionAgent("crispin", "Crispin", "Clander", Importance.None);

            world.Agents.Add(todi);
            world.Agents.Add(crispin);

            world.Map.Ubicate(todi, bedRoom);
            world.Map.Ubicate(crispin, bedRoom);

            var bed = new ArticledFurniture("bed", 400, 100, false, Genere.Femenine, Number.Singular);
            var table = new ArticledFurniture("table", 300, 50, false, Genere.Femenine, Number.Singular);
            var window = new ArticledFurniture("window", 25, 5, true, Genere.Femenine, Number.Singular);
            var rock = new ArticledItem("rock", 1, 1, Genere.Femenine, Number.Singular);
            var mochila = new ArticledContainerItem("mochila", 120, 1, Genere.Femenine, Number.Singular, 120, 50);
            var bolsa = new ArticledContainerItem("bolsa", 120, 1, Genere.Femenine, Number.Singular, 120, 50);
            var cuadro = new ArticledFurniture("cuadro", 25, 5, false, Genere.Masculine, Number.Singular);
            var lampara = new ArticledEnlightedFurniture("lampara", 25, 5, Genere.Femenine, Number.Singular);
            var humo = new SimpleFurniture("humo", 25, 5, false)
                .WithTurnPassed((world, turns) =>
                {
                    return Output.FromTexts("Tik tak");
                });
            lampara.Switch.TurnOn();

            world.Items.Add(bed);
            world.Items.Add(table);
            world.Items.Add(window);
            world.Items.Add(rock);
            world.Items.Add(mochila);
            world.Items.Add(bolsa);
            world.Items.Add(cuadro);
            world.Items.Add(lampara);
            world.Items.Add(humo);

            bedRoom.Items.Add(bed);
            bedRoom.Items.Add(table);
            bedRoom.Items.Add(window);
            bedRoom.Items.Add(rock);
            bedRoom.Items.Add(humo);

            bedRoom.Items.Hide(bed, table, window);

            corridor.Items.Add(cuadro);
            corridor.Items.Add(lampara);
            corridor.Items.Hide(cuadro, lampara);

            todi.Carrier.SetBack(mochila, world.Items);
            crispin.Carrier.SetBack(bolsa, world.Items);

            return world;
        }
    }
}
