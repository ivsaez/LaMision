using LaMision.Core.Elements;
using Agents;
using Items;
using ItemTypes;
using Mapping;
using StateMachine;
using Worlding;

namespace LaMision.Core
{
    public static class WorldBuilder
    {
        public static World Build()
        {
            var world = new World(MachineBuilder.Create()
                .WithState(States.Initial)
                    .WithTransition(States.Mision)
                .EndState()
                .Build());

            world.Time.IncreaseHours(17);

            var salita = new MisionMapped("salita", Externality.Internal, Genere.Femenine, Number.Singular);
            var radio = new MisionMapped("radio", Externality.Internal, Genere.Femenine, Number.Singular);

            world.Map.Add(salita);
            world.Map.Add(radio);

            //world.Map.Connect(bedRoom, corridor, Direction.East_West);

            var sujeto = new MisionAgent("sujeto", "Mirko", "Kazinsky", Importance.Main);
            sujeto.BecomeHuman();
            sujeto.Position.Machine.Transite(Position.Lying);

            var comandante = new MisionAgent("comandante", "Comandante", "Hoffmann", Importance.None);

            world.Agents.Add(sujeto);
            world.Agents.Add(comandante);

            world.Map.Ubicate(sujeto, salita);
            world.Map.Ubicate(comandante, radio);

            var rinonera = new ArticledContainerItem("rinonera", 40, 1, Genere.Femenine, Number.Singular, 40, 20);

            var tarjetaBlanca = new Tarjeta("tarjetaBlanca", 1, 1, Genere.Femenine, Number.Singular);
            var fluorescenteSalita = new ArticledEnlightedFurniture("fluorescenteSalita", 10, 5, Genere.Masculine, Number.Singular);
            fluorescenteSalita.Switch.TurnOn();
            var mesaSalita = new ArticledFurniture("mesaSalita", 150, 20, false, Genere.Femenine, Number.Singular);
            var escotilla = new ArticledFurniture("escotilla", 200, 60, false, Genere.Femenine, Number.Singular);
            var puertaSalita = new Puerta("puertaSalita", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaBlanca);

            //var window = new ArticledFurniture("window", 25, 5, true, Genere.Femenine, Number.Singular);
            //var humo = new SimpleFurniture("humo", 25, 5, false)
            //    .WithTurnPassed((world, turns) =>
            //    {
            //        return Output.FromTexts("Tik tak");
            //    });

            world.Items.Add(rinonera);
            world.Items.Add(tarjetaBlanca);
            world.Items.Add(fluorescenteSalita);
            world.Items.Add(mesaSalita);
            world.Items.Add(escotilla);
            world.Items.Add(puertaSalita);

            salita.Items.Add(fluorescenteSalita);
            salita.Items.Add(tarjetaBlanca);
            salita.Items.Add(mesaSalita);
            salita.Items.Add(escotilla);
            salita.Items.Add(puertaSalita);
            salita.Items.Hide(fluorescenteSalita, mesaSalita, escotilla, puertaSalita);

            sujeto.Carrier.SetBack(rinonera, world.Items);

            return world;
        }
    }

    public static class States
    {
        public static readonly string Initial = "Initial";
        public static readonly string Mision = "Mision";
    }
}
