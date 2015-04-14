using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using PokeCiv.View;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model;
using PokeCiv.Model.Battle;
using PokeCiv.Model.World;
using PokeCiv.Controllers;

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
            player1.AddToTeam(PokemonFactory.getPokemon(20, "CHARMANDER"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "SQUIRTLE"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "BULBASAUR"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "NINETALES"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "BEEDRILL"));
            player1.AddToTeam(PokemonFactory.getPokemon(20, "NIDORINO"));

            Controller c = new Controller(player1);
            Map m = new Map(c, "Field");
            //TODO: un-hardcode this
            m.setPlayerCoordinates(8, 6);
            c.Map = m;
            c.pokedexView = new PokedexView(c);
            //TODO: dit commentaar opruimen als Sjoerd t gelezen heeft
            // Bij het switchen van Map, haalt MapView n nieuwe map van Controller?
            // of maken we dan n nieuwe MapView aan? (in het laatste geval, new MapView(m) )
            //A : bij t switchen van map, laad je een niew grid in de bestaande mapView
            MapView mv = new MapView(c);
            c.mapView = mv;
            c.currentView = mv;
            new Thread(c.runView).Start();

            Console.ReadKey();

        }
    }
}
