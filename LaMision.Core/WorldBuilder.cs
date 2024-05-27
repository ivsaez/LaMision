using LaMision.Core.Elements;
using Agents;
using Items;
using ItemTypes;
using Mapping;
using StateMachine;
using Worlding;
using Languager.Extensions;
using Outputer;
using Rand;

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
                .WithState(States.Mision)
                    .WithTransition(States.Revelation)
                    .WithTransition(States.Fight)
                .EndState()
                .WithState(States.Revelation)
                    .WithTransition(States.Fight)
                .EndState()
                .WithState(States.Fight)
                    .WithTransition(States.Mision)
                    .WithTransition(States.Revelation)
                .EndState()
                .Build());

            world.Time.IncreaseHours(17);

            var nowhere = new MisionMapped("nowhere", Externality.Internal, Genere.Femenine, Number.Singular);
            var radio = new MisionMapped("radio", Externality.Internal, Genere.Femenine, Number.Singular);
            var salita = new MisionMapped("salita", Externality.Internal, Genere.Femenine, Number.Singular);
            var pasillo = new MisionMapped("pasillo", Externality.Internal, Genere.Masculine, Number.Singular);
            var salon = new MisionMapped("salon", Externality.Internal, Genere.Masculine, Number.Singular);
            var dormitorio = new MisionMapped("dormitorio", Externality.Internal, Genere.Masculine, Number.Singular);
            var lavabo = new MisionMapped("lavabo", Externality.Internal, Genere.Masculine, Number.Singular);
            var salaBoton = new MisionMapped("salaBoton", Externality.Internal, Genere.Femenine, Number.Singular);
            var salaControl = new MisionMapped("salaControl", Externality.Internal, Genere.Femenine, Number.Singular);
            var otroLavabo = new MisionMapped("otroLavabo", Externality.Internal, Genere.Masculine, Number.Singular);
            var otroSalon = new MisionMapped("otroSalon", Externality.Internal, Genere.Masculine, Number.Singular);
            var otroPasillo = new MisionMapped("otroPasillo", Externality.Internal, Genere.Masculine, Number.Singular);

            world.Map.Add(nowhere);
            world.Map.Add(radio);
            world.Map.Add(salita);
            world.Map.Add(pasillo);
            world.Map.Add(salon);
            world.Map.Add(dormitorio);
            world.Map.Add(lavabo);
            world.Map.Add(salaBoton);
            world.Map.Add(salaControl);
            world.Map.Add(otroLavabo);
            world.Map.Add(otroSalon);
            world.Map.Add(otroPasillo);

            world.Map.Connect(salaControl, salaBoton, Direction.East_West);
            world.Map.Connect(otroLavabo, otroSalon, Direction.East_West);
            world.Map.Connect(otroSalon, otroPasillo, Direction.North_South);

            var sujeto = new SimonEstevez("sujeto");
            sujeto.BecomeHuman();
            sujeto.Position.Machine.Transite(Position.Lying);

            var comandante = new MisionAgent("comandante", "Comandante", "Hoffmann", Importance.None);
            var natalia = new MisionAgent("natalia", "Natalia", "Hoffmann", Importance.None);
            natalia.Status.Machine.Transite(Status.Unconscious);
            var extrano = new MisionAgent("extrano", "un extraño", "personaje", Importance.None);
            extrano.Status.Machine.Transite(Status.Unconscious);

            world.Agents.Add(sujeto);
            world.Agents.Add(comandante);
            world.Agents.Add(natalia);
            world.Agents.Add(extrano);

            world.Map.Ubicate(sujeto, salita);
            world.Map.Ubicate(comandante, radio);
            world.Map.Ubicate(natalia, radio);
            world.Map.Ubicate(extrano, otroSalon);

            var rinonera = new ArticledContainerItem("rinonera", 40, 1, Genere.Femenine, Number.Singular, 40, 20);
            var dispositivo = new ArticledFurniture("dispositivo", 2, 1, false, Genere.Masculine, Number.Singular);

            var tarjetaBlanca = new Tarjeta("tarjetaBlanca", 1, 1, Genere.Femenine, Number.Singular);
            var tarjetaAzul = new Tarjeta("tarjetaAzul", 1, 1, Genere.Femenine, Number.Singular);
            var tarjetaNaranja = new Tarjeta("tarjetaNaranja", 1, 1, Genere.Femenine, Number.Singular);
            var tarjetaInexistente = new Tarjeta("tarjetaInexistente", 1, 1, Genere.Femenine, Number.Singular);

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
            var sillaRota = new ArticledFurniture("sillaRota", 30, 5, false, Genere.Femenine, Number.Singular);
            var sofa = new ArticledFurniture("sofa", 300, 60, false, Genere.Masculine, Number.Singular);
            var frasco = new Frasco("frasco");
            var armario = new ArticledContainerOpenableFurniture("armario", 1000, 40, false, Genere.Masculine, Number.Singular, 600, 100);
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
            var puertaNaranja = new Puerta("puertaNaranja", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaNaranja)
                .WithConnection(world =>
                {
                    var salaBoton = world.Map.Get("salaBoton");
                    var salon = world.Map.Get("salon");

                    if (salon.Exits.Has(salaBoton))
                        return string.Empty;

                    world.Map.Connect(salaBoton, salon, Direction.North_South);

                    return "salaBoton_view".trans();
                });

            var litera = new ArticledFurniture("litera", 400, 20, false, Genere.Femenine, Number.Singular);
            var rejilla = new ArticledFurniture("rejilla", 30, 1, false, Genere.Femenine, Number.Singular);
            var mesita = new ArticledContainerOpenableFurniture("mesita", 50, 20, false, Genere.Femenine, Number.Singular, 50, 50);
            var pared = new ArticledFurniture("pared", 1000, 60, false, Genere.Femenine, Number.Singular)
                .WithTurnPassed((world, turns) =>
                {
                    if (Rnd.Instance.Check(40) && extrano.IsAlive)
                    {
                        return Output.FromTexts(new string[]
                        {
                            "pared_text_1",
                            "pared_text_2",
                            "pared_text_3",
                            "pared_text_4",
                        }.Random().trans());
                    }

                    return Output.Empty;
                });

            var vater = new ArticledFurniture("vater", 30, 10, false, Genere.Masculine, Number.Singular);
            var lavadero = new ArticledFurniture("lavadero", 40, 10, false, Genere.Masculine, Number.Singular);
            var espejo = new ArticledFurniture("espejo", 50, 10, false, Genere.Masculine, Number.Singular);
            var espejoConsciente = new ArticledFurniture("espejoConsciente", 50, 10, false, Genere.Masculine, Number.Singular);

            var boton = new ArticledFurniture("boton", 40, 10, false, Genere.Masculine, Number.Singular);

            var cableNegro = new Cable("cableNegro");
            var cableBlanco = new Cable("cableBlanco");
            var cableGris = new Cable("cableGris");
            var cableRojo = new Cable("cableRojo");
            var cableAzul = new Cable("cableAzul");
            var cableAmarillo = new Cable("cableAmarillo");
            var interruptores = new Interruptores("interruptores");
            var palanca = new ArticledFurniture("palanca", 1, 1, false, Genere.Femenine, Number.Singular);

            var hueco = new ArticledFurniture("hueco", 30, 1, false, Genere.Masculine, Number.Singular);

            var otraPuertaLavabo = new Puerta("otraPuertaLavabo", 200, 20, false, Genere.Femenine, Number.Singular);
            otraPuertaLavabo.Openable.Open();
            var otraMesaSalon = new ArticledFurniture("otraMesaSalon", 150, 20, false, Genere.Femenine, Number.Singular);
            var otroSofa = new ArticledFurniture("otroSofa", 300, 60, false, Genere.Masculine, Number.Singular);
            var otroArmario = new ArticledContainerOpenableFurniture("otroArmario", 1000, 40, false, Genere.Masculine, Number.Singular, 600, 100);
            otroArmario.Openable.Open();
            var otraPuertaDormitorio = new Puerta("otraPuertaDormitorio", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaInexistente);
            var puertaRosa = new Puerta("puertaRosa", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaInexistente);

            var otraPuertaPasillo = new Puerta("otraPuertaPasillo", 200, 20, false, Genere.Femenine, Number.Singular);
            otraPuertaPasillo.Openable.Open();
            var otraTaquilla = new ArticledContainerOpenableFurniture("otraTaquilla", 600, 20, false, Genere.Femenine, Number.Singular, 600, 100);
            otraTaquilla.Openable.Open();
            var plasticos = new ArticledFurniture("plasticos", 3, 1, false, Genere.Masculine, Number.Plural);
            var otraPuertaSalita = new Puerta("otraPuertaSalita", 200, 20, false, Genere.Femenine, Number.Singular, tarjetaInexistente);

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
            world.Items.Add(sillaRota);
            world.Items.Add(sofa);
            world.Items.Add(puertaDormitorio);
            world.Items.Add(puertaLavabo);
            world.Items.Add(tarjetaAzul);
            world.Items.Add(litera);
            world.Items.Add(mesita);
            world.Items.Add(vater);
            world.Items.Add(lavadero);
            world.Items.Add(espejo);
            world.Items.Add(espejoConsciente);
            world.Items.Add(tarjetaNaranja);
            world.Items.Add(frasco);
            world.Items.Add(armario);
            world.Items.Add(puertaNaranja);
            world.Items.Add(boton);
            world.Items.Add(pared);
            world.Items.Add(rejilla);
            world.Items.Add(cableNegro);
            world.Items.Add(cableBlanco);
            world.Items.Add(cableGris);
            world.Items.Add(cableAzul);
            world.Items.Add(cableRojo);
            world.Items.Add(cableAmarillo);
            world.Items.Add(interruptores);
            world.Items.Add(palanca);
            world.Items.Add(hueco);
            world.Items.Add(otraPuertaLavabo);
            world.Items.Add(otraMesaSalon);
            world.Items.Add(otroSofa);
            world.Items.Add(otroArmario);
            world.Items.Add(otraPuertaDormitorio);
            world.Items.Add(puertaRosa);
            world.Items.Add(tarjetaInexistente);
            world.Items.Add(otraPuertaPasillo);
            world.Items.Add(otraTaquilla);
            world.Items.Add(plasticos);
            world.Items.Add(otraPuertaSalita);

            nowhere.Items.Add(tarjetaNaranja);
            nowhere.Items.Add(rejilla);
            nowhere.Items.Add(tarjetaInexistente);
            nowhere.Items.Add(sillaRota);
            nowhere.Items.Add(espejoConsciente);

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
            taquilla.Inventory.Add(trajePlastico, world.Items);
            pasillo.Items.Hide(luzRoja, taquilla, dispositivo, puertaPasillo);

            salon.Items.Add(dispositivo);
            salon.Items.Add(luzRoja);
            salon.Items.Add(mesaSalon);
            salon.Items.Add(silla);
            salon.Items.Add(sofa);
            salon.Items.Add(puertaDormitorio);
            salon.Items.Add(puertaLavabo);
            salon.Items.Add(armario);
            salon.Items.Add(puertaNaranja);
            armario.Inventory.Add(frasco, world.Items);
            salon.Items.Hide(luzRoja, dispositivo, mesaSalon, silla, sofa, puertaDormitorio, puertaLavabo, armario, puertaNaranja);

            dormitorio.Items.Add(luzRoja);
            dormitorio.Items.Add(litera);
            dormitorio.Items.Add(mesita);
            dormitorio.Items.Add(pared);
            mesita.Inventory.Add(tarjetaAzul, world.Items);
            dormitorio.Items.Hide(luzRoja, mesita, litera, pared);

            lavabo.Items.Add(luzRoja);
            lavabo.Items.Add(vater);
            lavabo.Items.Add(lavadero);
            lavabo.Items.Add(espejo);
            lavabo.Items.Hide(vater, lavadero, espejo, luzRoja);

            salaBoton.Items.Add(luzRoja);
            salaBoton.Items.Add(dispositivo);
            salaBoton.Items.Add(boton);
            salaBoton.Items.Hide(boton, luzRoja, dispositivo);

            salaControl.Items.Add(luzRoja);
            salaControl.Items.Add(cableNegro);
            salaControl.Items.Add(cableBlanco);
            salaControl.Items.Add(cableGris);
            salaControl.Items.Add(cableAzul);
            salaControl.Items.Add(cableRojo);
            salaControl.Items.Add(cableAmarillo);
            salaControl.Items.Add(interruptores);
            salaControl.Items.Add(palanca);
            salaControl.Items.Hide(
                luzRoja, 
                cableNegro, 
                cableBlanco, 
                cableGris, 
                cableAzul, 
                cableRojo, 
                cableAmarillo,
                interruptores,
                palanca);

            otroLavabo.Items.Add(luzRoja);
            otroLavabo.Items.Add(vater);
            otroLavabo.Items.Add(lavadero);
            otroLavabo.Items.Add(espejo);
            otroLavabo.Items.Add(hueco);
            otroLavabo.Items.Hide(vater, lavadero, espejo, luzRoja, hueco);

            otroSalon.Items.Add(luzRoja);
            otroSalon.Items.Add(dispositivo);
            otroSalon.Items.Add(otraPuertaLavabo);
            otroSalon.Items.Add(otraMesaSalon);
            otroSalon.Items.Add(otroSofa);
            otroSalon.Items.Add(otroArmario);
            otroSalon.Items.Add(otraPuertaDormitorio);
            otroSalon.Items.Add(puertaRosa);
            otroSalon.Items.Hide(
                otraPuertaLavabo, 
                luzRoja, 
                dispositivo, 
                otraMesaSalon, 
                otroSofa, 
                otroArmario, 
                otraPuertaDormitorio, 
                puertaRosa);

            otroPasillo.Items.Add(luzRoja);
            otroPasillo.Items.Add(otraTaquilla);
            otroPasillo.Items.Add(dispositivo);
            otroPasillo.Items.Add(otraPuertaPasillo);
            otroPasillo.Items.Add(plasticos);
            otroPasillo.Items.Add(otraPuertaSalita);
            otroPasillo.Items.Hide(
                luzRoja, 
                otraTaquilla, 
                dispositivo, 
                otraPuertaPasillo, 
                plasticos,
                otraPuertaSalita);

            sujeto.Carrier.SetBack(rinonera, world.Items);

            return world;
        }
    }

    public static class States
    {
        public static readonly string Initial = "Initial";
        public static readonly string Mision = "Mision";
        public static readonly string Revelation = "Revelation";
        public static readonly string Fight = "Fight";
    }
}
