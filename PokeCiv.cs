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
            player1.AddToTeam(PokemonFactory.getPokemon(15, "GASTLY"));
            player1.AddToTeam(PokemonFactory.getPokemon(2, "SQUIRTLE"));
            player1.AddToTeam(PokemonFactory.getPokemon(2, "BULBASAUR"));
            player1.AddToTeam(PokemonFactory.getPokemon(2, "NINETALES"));
            player1.AddToTeam(PokemonFactory.getPokemon(2, "BEEDRILL"));
            player1.AddToTeam(PokemonFactory.getPokemon(2, "NIDORINO"));

            Controller c = new Controller(player1);
            Map m = new Map(c, "Field");

            string[] ascii = CaveGeneration.generateASCIIMap(8, 6);
            //string[] ascii = new string[]{
            //    "xxxxxxxxxxxxxxxxxxx     ",
            //    "x    xx    x b  ww b    ",
            //    "x ww xx      b ww   b   ",
            //    "x ww     uuu b       b  ",
            //    "x ww    uuuu b xx    uu ",
            //    "x       uuu  b xx    uuu",
            //    "xx      www  b xxww    u",
            //    "xx   bbbwww  b xxww    u",
            //    "xxw  xxxxww  b xxww  x u",
            //    "xwww xxw  w wwwwwww  x u",
            //    "xwwwwwww  w bbbwwwww x u",
            //    "x ww www     bwwwwww x u",
            //    "x    www     bwwwwww x x",
            //    "xx           uuwwwww x u",
            //    "xx    bbbbb  uuwwwww x u",
            //    "x    xx        wwwww uuu",
            //    "x ww xx        wwwww uuu",
            //    "x wwxx      wwwwwwww uuu",
            //    "x wwxx               uuu",
            //    "x           x        uu ",
            //    "uuu    u    xwwwwwww b  ",
            //    " uuu  uu     wwwwwww b  ",
            //    "   uuuuxxxxxxxxxxxxxxb  "
            //};

            Dictionary<Char, TileItem> lookup = new Dictionary<char, TileItem>();
            // encounters = {0.45: ("PIDGEY", 2, 4), 0.3:("RATTATA",2,2), 0.2:("SENTRET",3,3), 0.05:("FURRET",6,6)}
            ArrayList testWildPokemon = new ArrayList();
            testWildPokemon.Add(new Encounter("LUGIA", 5, 10, 1.0));
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

            //Hardcoded enemy
            //Player enemy = new Player("Team Rocket Grunt");
            //enemy.AddToTeam(PokemonFactory.getPokemon(10, "ZUBAT"));
            //enemy.AddToTeam(PokemonFactory.getPokemon(10, "KOFFING"));
            //enemy.AddToTeam(PokemonFactory.getPokemon(10, "EKANS"));
            //c.switchFromMapToBattle(enemy);

            Console.ReadKey();

        }
    }
}
