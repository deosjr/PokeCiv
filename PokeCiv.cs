using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;

using PokeCiv.View;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model;
using PokeCiv.Model.Battle;
using PokeCiv.Model.World;
using PokeCiv.Controllers;
using PokeCiv.Model.World.Tiles.TileItems;
using PokeCiv.Model.World.Tiles;

namespace PokeCiv
{
    class PokeCiv
    {
        [STAThread]
        static void Main(string[] args)
        {

            //Debug values
            //Random r = Mechanics.random;
            Player player1 = new Player("P1");
            player1.AddToTeam(PokemonFactory.getPokemon(15, "CHARMANDER"));
            player1.AddToTeam(PokemonFactory.getPokemon(15, "SQUIRTLE"));
            player1.AddToTeam(PokemonFactory.getPokemon(15, "BULBASAUR"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "NINETALES"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "BEEDRILL"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "NIDORINO"));

            Controller c = new Controller(player1);
            Map m = new Map(c, "Field");

            string[] ascii = CaveGeneration.generateASCIIMap(8, 6);

            Dictionary<Char, TileItem> lookup = new Dictionary<char, TileItem>();
            // encounters = {0.45: ("PIDGEY", 2, 4), 0.3:("RATTATA",2,2), 0.2:("SENTRET",3,3), 0.05:("FURRET",6,6)}
            ArrayList testWildPokemon = new ArrayList();
            testWildPokemon.Add(new Encounter("KLINKLANG", 1, 100, 1.0));
            lookup.Add('w', new Grass(testWildPokemon, 0.1));
            lookup.Add('u', new Water());
            lookup.Add('x', new Block());
            TileItem bush = new Block();
            bush.imageSrc = "../../Data/Graphics/Tiles/bush.png";
            lookup.Add('b', bush);

            m.GridFromASCII(ascii, lookup);
            //TODO: un-hardcode this
            m.setPlayerCoordinates(8, 6);
            c.Map = m;
            c.pokedexView = new PokedexView(c);
            MapView mv = new MapView(c);
            c.mapView = mv;
            c.currentView = mv;
            new Thread(c.runView).Start();

            Console.ReadKey();

        }
    }
}
