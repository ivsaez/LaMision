using LaMision.Core.Elements;
using Agents;
using Items;
using ItemTypes;
using Mapping;
using StateMachine;
using Worlding;
using Languager.Extensions;
using Items.Extensions;

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

            var radio = new MisionMapped("radio", Externality.Internal, Genere.Femenine, Number.Singular);
            var salita = new MisionMapped("salita", Externality.Internal, Genere.Femenine, Number.Singular);
            var pasillo = new MisionMapped("pasillo", Externality.Internal, Genere.Masculine, Number.Singular);
            var salon = new MisionMapped("salon", Externality.Internal, Genere.Masculine, Number.Singular);
            var dormitorio = new MisionMapped("dormitorio", Externality.Internal, Genere.Masculine, Number.Singular);
            var lavabo = new MisionMapped("lavabo", Externality.Internal, Genere.Masculine, Number.Singular);

            world.Map.Add(radio);
            world.Map.Add(salita);
            world.Map.Add(pasillo);
            world.Map.Add(salon);
            world.Map.Add(dormitorio);
            world.Map.Add(lavabo);

            var sujeto = new MisionAgent("sujeto", "Mirko", "Kazinsky", Importance.Main);
            sujeto.BecomeHuman();
            sujeto.Position.Machine.Transite(Position.Lying);

            var comandante = new MisionAgent("comandante", "Comandante", "Hoffmann", Importance.None);

            world.Agents.Add(sujeto);
            world.Agents.Add(comandante);

            world.Map.Ubicate(sujeto, salita);
            world.Map.Ubicate(comandante, radio);

            var rinonera = new ArticledContainerItem("rinonera", 40, 1, Genere.Femenine, Number.Singular, 40, 20);
            var dispositivo = new ArticledFurniture("dispositivo", 2, 1, false, Genere.Masculine, Number.Singular);

            var tarjetaBlanca = new Tarjeta("tarjetaBlanca", 1, 1, Genere.Femenine, Number.Singular);
            var tarjetaAzul = new Tarjeta("tarjetaAzul", 1, 1, Genere.Femenine, Number.Singular);

            var fluorescenteSalita = new ArticledEnlightedFurniture("fluorescenteSalita", 10, 5, Genere.Masculine, Number.Singular);
            fluorescenteSalita.Switch.TurnOn();
            var mesaSalita = new ArticledFurniture("mesaSalita", 150, 20, false, Genere.Femenine, Number.Singular);
            var escotilla = new ArticledFurniture("escotilla", 200, 60, false, Genere.Femenine, Number.Singular);
            var puertaSalita = new Puerta("puertaSalita", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaBlanca)
                .WithConnection(world =>
                {
                    var salita = world.Map.Get("salita");
                    var pasillo = world.Map.Get("pasillo");

                    if (salita.Exits.Has(pasillo))
                        return string.Empty;

                    world.Map.Connect(pasillo, salita, Direction.North_South);

                    return "pasillo_view".trans();
                });

            var luzRoja = new ArticledEnlightedFurniture("luzRoja", 2, 2, Genere.Femenine, Number.Singular);
            luzRoja.Switch.TurnOn();
            var taquilla = new ArticledContainerOpenableFurniture("taquilla", 600, 20, false, Genere.Femenine, Number.Singular, 600, 100);
            var trajePlastico = new ArticledFurniture("trajePlastico", 100, 5, false, Genere.Masculine, Number.Singular);
            var puertaPasillo = new Puerta("puertaPasillo", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaBlanca)
                .WithConnection(world =>
                {
                    var pasillo = world.Map.Get("pasillo");
                    var salon = world.Map.Get("salon");

                    if (pasillo.Exits.Has(salon))
                        return string.Empty;

                    world.Map.Connect(salon, pasillo, Direction.North_South);

                    return "salon_view".trans();
                });

            var mesaSalon = new ArticledFurniture("mesaSalon", 150, 20, false, Genere.Femenine, Number.Singular);
            var silla = new ArticledFurniture("silla", 30, 5, false, Genere.Femenine, Number.Singular);
            var sofa = new ArticledFurniture("sofa", 300, 60, false, Genere.Masculine, Number.Singular);
            var puertaDormitorio = new Puerta("puertaDormitorio", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaBlanca)
                .WithConnection(world =>
                {
                    var salon = world.Map.Get("salon");
                    var dormitorio = world.Map.Get("dormitorio");

                    if (salon.Exits.Has(dormitorio))
                        return string.Empty;

                    world.Map.Connect(salon, dormitorio, Direction.East_West);

                    return "dormitorio_view".trans();
                });
            var puertaLavabo = new Puerta("puertaLavabo", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaAzul)
                .WithConnection(world =>
                {
                    var salon = world.Map.Get("salon");
                    var lavabo = world.Map.Get("lavabo");

                    if (salon.Exits.Has(lavabo))
                        return string.Empty;

                    world.Map.Connect(lavabo, salon, Direction.East_West);

                    return "lavabo_view".trans();
                });

            world.Items.Add(rinonera);
            world.Items.Add(tarjetaBlanca);
            world.Items.Add(fluorescenteSalita);
            world.Items.Add(mesaSalita);
            world.Items.Add(escotilla);
            world.Items.Add(puertaSalita);
            world.Items.Add(luzRoja);
            world.Items.Add(taquilla);
            world.Items.Add(trajePlastico);
            world.Items.Add(dispositivo);
            world.Items.Add(puertaPasillo);
            world.Items.Add(mesaSalon);
            world.Items.Add(silla);
            world.Items.Add(sofa);
            world.Items.Add(puertaDormitorio);
            world.Items.Add(puertaLavabo);
            world.Items.Add(tarjetaAzul);

            salita.Items.Add(fluorescenteSalita);
            salita.Items.Add(tarjetaBlanca);
            salita.Items.Add(mesaSalita);
            salita.Items.Add(escotilla);
            salita.Items.Add(puertaSalita);
            salita.Items.Add(dispositivo);
            salita.Items.Hide(fluorescenteSalita, mesaSalita, escotilla, puertaSalita, dispositivo);

            pasillo.Items.Add(luzRoja);
            pasillo.Items.Add(taquilla);
            pasillo.Items.Add(dispositivo);
            pasillo.Items.Add(puertaPasillo);
            taquilla.Cast<IContainer>().Inventory.Add(trajePlastico, world.Items);
            pasillo.Items.Hide(luzRoja, taquilla, dispositivo, puertaPasillo);

            salon.Items.Add(dispositivo);
            salon.Items.Add(luzRoja);
            salon.Items.Add(mesaSalon);
            salon.Items.Add(silla);
            salon.Items.Add(sofa);
            salon.Items.Add(puertaDormitorio);
            salon.Items.Add(puertaLavabo);
            salon.Items.Hide(luzRoja, dispositivo, mesaSalon, silla, sofa, puertaDormitorio, puertaLavabo);

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
